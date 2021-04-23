using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.NetMonitoring;
using DataAccessLayer.Repositories.EFRepositories.NetMonitoring;
using DataAccessLayer.Repositories.Interfaces.NetMonitoring;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace StatusShopBot
{
    class Program
    {
        private readonly static string token = "1643703787:AAH4S8zGMVeMzl59FczNvv6afiewTYCfRtA";
        private readonly static string connectionStringSQL08 = "Data Source=sql08;Initial Catalog=NetMonitoring;Persist Security Info=True;User ID=j-sql08-read-NetMonitoring;Password=9g0sl3l9z1l0;Connection Timeout=150";
        
        private static TelegramBotClient botClient;

        private static List<StatusShopModel> statusShopModels = new List<StatusShopModel>();
        private static List<StatusShopModel> failStatusShopModels = new List<StatusShopModel>();

        static async Task Main(string[] args)
        {
           
            IServiceCollection serviceCollection = new ServiceCollection()
                .AddLogging()
                .AddDbContext<NetMonitoringContext>(opts => opts.UseSqlServer(connectionStringSQL08))
                .AddScoped<IMonitoringRepository, MonitoringRepository>();

            IServiceProvider services = serviceCollection.BuildServiceProvider();

            IMonitoringRepository monitoringRepository = services.GetService<IMonitoringRepository>();

            botClient = new TelegramBotClient(token);
            var info = botClient.GetMeAsync().Result;
            Console.WriteLine($"Мой Id {info.Id}, {info.FirstName}");

            Program program = new Program();

            Timer timer = new Timer(300000);
            timer.Elapsed += async (sender, e) => await program.getStatus(monitoringRepository);
            timer.Start();

            await program.getStatus(monitoringRepository);

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            Console.ReadKey();

            botClient.StopReceiving();
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                await botClient.SendTextMessageAsync(
                  chatId: e.Message.Chat,
                  text: "You said:\n" + e.Message.Text
                );
            }
        }

        public async Task getStatus(IMonitoringRepository monitoringRepository)
        {
            List<Monitoring> monitorings = await monitoringRepository.getAllLogs(10);
            if (monitorings.Count != 0)
            {
                List<StatusShopModel> newlist = new List<StatusShopModel>();
                int nstock = 1;
                bool isNullP = false;
                bool isFail = false;
                foreach (Monitoring monitoring in monitorings)
                {
                    if (monitoring.Stock == nstock)
                    {
                        string device = monitoring.Device;
                        char typeDevice = device[0];

                        if ((monitoring.IpAddress == "0.0.0.0") || (monitoring.IpAddress == null))
                        {
                            isNullP = true;
                        }

                        if ((typeDevice == 'P') && (monitoring.Status == 1) )
                        {
                            isNullP = false;
                            newlist.Add(new StatusShopModel { ShopId = monitoring.Stock, Status = true, LogTime = monitoring.LogTime });
                            nstock++;
                            continue;
                        }

                    }

                    if (monitoring.Stock == nstock + 1)
                    {
                        if (isNullP)
                        {
                            newlist.Add(new StatusShopModel { ShopId = nstock, Status = true, LogTime = monitoring.LogTime });
                            nstock++;
                        }
                        if (!isNullP)
                        {
                            newlist.Add(new StatusShopModel { ShopId = nstock, Status = false, LogTime = monitoring.LogTime });
                            nstock++;
                        }
                    }
                }

                if (statusShopModels.Count != 0)
                {
                    foreach (StatusShopModel statusShop in statusShopModels)
                    {
                        foreach (StatusShopModel newl in newlist)
                        {
                            if (statusShop.ShopId == newl.ShopId)
                            {
                                if (statusShop.Status != newl.Status)
                                {
                                    if (newl.Status)
                                    {
                                        string notification = $"\U00002705 Постачання відновлено \nМагазин № {newl.ShopId} \nЧас втрати 234 \nЧас відновлення {newl.LogTime}";

                                        await botClient.SendTextMessageAsync(
                                            chatId: "309516361",
                                            text: notification
                                            );
                                    }


                                    if (!newl.Status)
                                    {
                                        foreach (StatusShopModel fail in failStatusShopModels)
                                        {
                                            if( fail.ShopId == newl.ShopId)
                                            {
                                                isFail = true;

                                                string notification = $"\U0000274C Втрата електропостачання \U0000203C\nМагазин № {newl.ShopId} \nЧас фіксації {newl.LogTime}";

                                                await botClient.SendTextMessageAsync(
                                                    chatId: "309516361",
                                                    text: notification
                                                    );
                                            }
                                        }

                                        if (!isFail)
                                        {
                                            failStatusShopModels.Add(new StatusShopModel { ShopId = newl.ShopId , LogTime = newl.LogTime });
                                        }

                                        isFail = false;
                                    }
                                    Console.WriteLine("Произошли изменения в " + statusShop.ShopId);
                                }
                                break;
                            }
                        }
                    }
                }
                statusShopModels = newlist;

                foreach (StatusShopModel statusShopModel in statusShopModels)
                {
                    Console.WriteLine($"{statusShopModel.ShopId} {statusShopModel.Status} {statusShopModel.LogTime}");
                }
            }
            Console.WriteLine(monitorings.Count);
            Console.WriteLine(DateTime.Now);
        }
    }
}
