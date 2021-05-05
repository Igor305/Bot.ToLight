using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.NetMonitoring;
using DataAccessLayer.Entities.Shops;
using DataAccessLayer.Repositories.EFRepositories.NetMonitoring;
using DataAccessLayer.Repositories.EFRepositories.Shops;
using DataAccessLayer.Repositories.Interfaces.NetMonitoring;
using DataAccessLayer.Repositories.Interfaces.Shops;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using Telegram.Bot;

namespace StatusShopBot
{
    class Program
    {
        private readonly static string token = "1643703787:AAH4S8zGMVeMzl59FczNvv6afiewTYCfRtA";
        private readonly static string connectionStringSQL08 = "Data Source=sql08;Initial Catalog=NetMonitoring;Persist Security Info=True;User ID=j-sql08-read-NetMonitoring;Password=9g0sl3l9z1l0;Connection Timeout=150";
        private readonly static string connectionStringSQL26 = "Data Source=sql26;Initial Catalog=Shops;Persist Security Info=True;User ID=j-sql26-reader-shops;Password=1GAxzpWtGojxCWnW8sYY";

        private static TelegramBotClient botClient;

        private static List<StatusShopModel> statusShopModels = new List<StatusShopModel>();
        private static List<StatusShopModel> failStatusShopModels = new List<StatusShopModel>();

        static async Task Main(string[] args)
        {
           
            IServiceCollection serviceCollection = new ServiceCollection()
                .AddLogging()
                .AddDbContext<NetMonitoringContext>(opts => opts.UseSqlServer(connectionStringSQL08))
                .AddDbContext<ShopsContext>(opts => opts.UseSqlServer(connectionStringSQL26))
                .AddScoped<IMonitoringRepository, MonitoringRepository>()
                .AddScoped<IShopsRepository, ShopsRepository>()
                .AddScoped<IShopWorkTimesRepository, ShopWorkTimesRepository>();

            IServiceProvider services = serviceCollection.BuildServiceProvider();

            IMonitoringRepository monitoringRepository = services.GetService<IMonitoringRepository>();
            IShopsRepository shopsRepository = services.GetService<IShopsRepository>();
            IShopWorkTimesRepository shopWorkTimesRepository = services.GetService<IShopWorkTimesRepository>();

            botClient = new TelegramBotClient(token);
            var info = botClient.GetMeAsync().Result;
            Console.WriteLine($"Мой Id {info.Id}, {info.FirstName}");

            Program program = new Program();

            Timer timer = new Timer(300000);
            timer.Elapsed += async (sender, e) => await program.getStatus(monitoringRepository, shopsRepository, shopWorkTimesRepository);
            timer.Start();

            await program.getStatus(monitoringRepository, shopsRepository, shopWorkTimesRepository);

            botClient.StartReceiving();

            Console.ReadKey();

            botClient.StopReceiving();
        }

        public async Task getStatus(IMonitoringRepository monitoringRepository, IShopsRepository shopsRepository, IShopWorkTimesRepository shopWorkTimesRepository)
        {
            try
            {
                List<Shop> shops = await shopsRepository.getAllShops();
                List<ShopWorkTime> shopWorkTimes = await shopWorkTimesRepository.getTimeToDay();
                List<Monitoring> monitorings = await monitoringRepository.getAllLogs(20);

                if (monitorings.Count != 0)
                {

                    List<StatusShopModel> newlist = new List<StatusShopModel>();
                    int nstock = 1;

                    bool isNullP = false;
                    bool isFound = false;

                    DateTime dateFrom = DateTime.Now;
                    DateTime dateTo = DateTime.Now;

                    // ------------------------------------------------------------------------ алгоритм статуса магазина --------------------------------------------------------
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

                            if ((typeDevice == 'P') && (monitoring.Status == 1))
                            {
                                isNullP = false;
                                newlist.Add(new StatusShopModel { ShopId = monitoring.Stock, Status = 1, LogTime = monitoring.LogTime });
                                nstock++;
                                continue;
                            }

                        }

                        if (monitoring.Stock == nstock + 1)
                        {
                            if (isNullP)
                            {
                                newlist.Add(new StatusShopModel { ShopId = nstock, Status = -1, LogTime = monitoring.LogTime });
                                nstock++;
                            }
                            if (!isNullP)
                            {
                                newlist.Add(new StatusShopModel { ShopId = nstock, Status = 0, LogTime = monitoring.LogTime });
                                nstock++;
                            }
                        }
                    }

                    // ------------------------------------------------------------------------ определение времени работы магазина ---------------------------------------------
                    if (statusShopModels.Count != 0)
                    {
                        foreach (StatusShopModel statusShop in statusShopModels)
                        {
                            foreach (Shop shop in shops)
                            {
                                if (statusShop.ShopId == shop.ShopNumber)
                                {
                                    foreach (ShopWorkTime shopWorkTime in shopWorkTimes)
                                    {
                                        if (shop.ShopWorkTimeId == shopWorkTime.Id)
                                        {
                                            switch (DateTime.Today.DayOfWeek)
                                            {
                                                case DayOfWeek.Monday: dateFrom = shopWorkTime.MondayFrom; dateTo = shopWorkTime.MondayTo; break;
                                                case DayOfWeek.Tuesday: dateFrom = shopWorkTime.TuesdayFrom; dateTo = shopWorkTime.TuesdayTo; break;
                                                case DayOfWeek.Wednesday: dateFrom = shopWorkTime.WednesdayFrom; dateTo = shopWorkTime.WednesdayTo; break;
                                                case DayOfWeek.Thursday: dateFrom = shopWorkTime.ThursdayFrom; dateTo = shopWorkTime.ThursdayTo; break;
                                                case DayOfWeek.Friday: dateFrom = shopWorkTime.FridayFrom; dateTo = shopWorkTime.FridayTo; break;
                                                case DayOfWeek.Saturday: dateFrom = shopWorkTime.SaturdayFrom; dateTo = shopWorkTime.SaturdayTo; break;
                                                case DayOfWeek.Sunday: dateFrom = shopWorkTime.SundayFrom; dateTo = shopWorkTime.SundayTo; break;

                                                default: dateFrom = shopWorkTime.MondayFrom; dateTo = shopWorkTime.MondayTo; break;
                                            }

                                            //------------------------------------------------------------------------------ рабочее время ---------------------------------

                                            if ((DateTime.Now.Hour >= dateFrom.Hour) && (DateTime.Now.Hour < dateTo.Hour))
                                            {
                                                foreach (StatusShopModel newl in newlist)
                                                {
                                                    newl.isWork = true;

                                                    if (statusShop.ShopId == newl.ShopId)
                                                    {
                                                        if (statusShop.Status != newl.Status)
                                                        {
                                                            if ((newl.Status == -1))
                                                            {
                                                                newl.Status = statusShop.Status;
                                                                break;
                                                            }

                                                            if (newl.Status == 1)
                                                            {
                                                                StatusShopModel errorShopsModel = new StatusShopModel();

                                                                foreach (StatusShopModel fail in failStatusShopModels)
                                                                {
                                                                    if (newl.ShopId == fail.ShopId)
                                                                    {
                                                                        isFound = true;

                                                                        string notification = $"\U00002705 Постачання відновлено \nМагазин № {newl.ShopId} \nЧас втрати {fail.LogTime} \nЧас відновлення {newl.LogTime}";

                                                                        await botClient.SendTextMessageAsync(
                                                                            chatId: "-1001395707277",
                                                                            text: notification
                                                                            );

                                                                        await botClient.SendTextMessageAsync(
                                                                            chatId: "309516361",
                                                                            text: notification
                                                                            );

                                                                        errorShopsModel = fail;
                                                                    }
                                                                }

                                                                if (isFound)
                                                                {
                                                                    failStatusShopModels.Remove(errorShopsModel);
                                                                }

                                                                if (!isFound)
                                                                {
                                                                    string notification = $"\U00002705 Постачання відновлено \nМагазин № {newl.ShopId} \nЧас відновлення {newl.LogTime}";

                                                                    await botClient.SendTextMessageAsync(
                                                                        chatId: "-1001395707277",
                                                                        text: notification
                                                                        );

                                                                    await botClient.SendTextMessageAsync(
                                                                        chatId: "309516361",
                                                                        text: notification
                                                                        );

                                                                }
                                                                isFound = false;
                                                            }

                                                            if (newl.Status == 0)
                                                            {

                                                                string notification = $"\U0000274C Втрата електропостачання \U0000203CМагазин № {newl.ShopId} \nЧас фіксації {newl.LogTime}";

                                                                await botClient.SendTextMessageAsync(
                                                                    chatId: "-1001395707277",
                                                                    text: notification
                                                                    );

                                                                await botClient.SendTextMessageAsync(
                                                                    chatId: "309516361",
                                                                    text: notification
                                                                    );

                                                                failStatusShopModels.Add(new StatusShopModel { ShopId = newl.ShopId, LogTime = newl.LogTime });
                                                            }
                                                        }
                                                        break;
                                                    }
                                                }
                                            }

                                            //--------------------------------------------------------------------- В НЕ рабочее время и для магазинов без графика работы -----------------------------------------------

                                            if ((DateTime.Now.Hour < dateFrom.Hour) || (DateTime.Now.Hour >= dateTo.Hour))
                                            {
                                                foreach (StatusShopModel newl in newlist)
                                                {
                                                    if (statusShop.ShopId == newl.ShopId)
                                                    {
                                                        if (statusShop.Status != newl.Status)
                                                        {
                                                            if ((newl.Status == -1))
                                                            {
                                                                newl.Status = statusShop.Status;
                                                                break;
                                                            }

                                                            if (newl.Status == 1)
                                                            {
                                                                StatusShopModel errorShopsModel = new StatusShopModel();

                                                                foreach (StatusShopModel fail in failStatusShopModels)
                                                                {
                                                                    if (newl.ShopId == fail.ShopId)
                                                                    {
                                                                        isFound = true;
                                                                        errorShopsModel = fail;
                                                                    }

                                                                }

                                                                if (isFound)
                                                                {
                                                                    failStatusShopModels.Remove(errorShopsModel);
                                                                }
                                                            }

                                                            if (newl.Status == 0)
                                                            {
                                                                failStatusShopModels.Add(new StatusShopModel { ShopId = newl.ShopId, LogTime = newl.LogTime });
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    statusShopModels = newlist;

                    foreach (StatusShopModel statusShopModel in statusShopModels)
                    {
                        Console.WriteLine($"{statusShopModel.ShopId} {statusShopModel.Status} {statusShopModel.LogTime} {statusShopModel.isWork}");
                    }
                }

                Console.WriteLine(monitorings.Count);
                Console.WriteLine(DateTime.Now);

                foreach (StatusShopModel statusShopModel in failStatusShopModels)
                {
                    Console.WriteLine($"{statusShopModel.ShopId} {statusShopModel.Status} {statusShopModel.LogTime}");
                }
            }

            catch
            {
                return;
            }
        }
    }
}
