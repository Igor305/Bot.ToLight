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
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace StatusShopBot
{
    public class Program
    {
        private readonly static string token = "1643703787:AAH4S8zGMVeMzl59FczNvv6afiewTYCfRtA";
        private readonly static string connectionStringSQL08 = "Data Source=sql08;Initial Catalog=NetMonitoring;Persist Security Info=True;User ID=j-sql08-read-NetMonitoring;Password=9g0sl3l9z1l0;Connection Timeout=150";
        private readonly static string connectionStringSQL26 = "Data Source=sql26;Initial Catalog=Shops;Persist Security Info=True;User ID=j-sql26-reader-shops;Password=1GAxzpWtGojxCWnW8sYY";

        private readonly static string creatorId = "309516361";
        private readonly static string testChatId = "-1001395707277";
        private readonly static string chatId = "-1001158034358";
        private readonly static string pathLog = "BotToLigthLog.txt";
        private readonly static string pathLogFail = "BotToLigthLogFail.txt";

        private static TelegramBotClient botClient;

        private static List<StatusShopModel> statusShopModels = new List<StatusShopModel>();
        private static List<StatusShopModel> failStatusShopModels = new List<StatusShopModel>();

        public static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.start();
        }

        public async Task start()
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

            /*Timer timer = new Timer(300000);
            timer.Elapsed += async (sender, e) => await program.getStatus(monitoringRepository, shopsRepository, shopWorkTimesRepository);
            timer.Start();*/

            botClient.StartReceiving();

            await getStatus(monitoringRepository, shopsRepository, shopWorkTimesRepository);

           // System.Threading.Thread.Sleep(-1);
        }

        public async Task getStatus(IMonitoringRepository monitoringRepository, IShopsRepository shopsRepository, IShopWorkTimesRepository shopWorkTimesRepository)
        {
            try
            {
                string not = "BotToLight inWork";

                await botClient.SendTextMessageAsync(
                    chatId: creatorId,
                    text: not
                    );

                string result = "";
                string resultFail = "";

                List<Shop> shops = await shopsRepository.getAllShops();
                List<ShopWorkTime> shopWorkTimes = await shopWorkTimesRepository.getTimeToDay();
                List<Monitoring> monitorings = await monitoringRepository.getAllLogs(20);

                await readFromFile();          

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
                                                                            chatId: testChatId,
                                                                            text: notification
                                                                            );

                                                                        try
                                                                        {
                                                                            await botClient.SendTextMessageAsync(
                                                                                chatId: chatId,
                                                                                text: notification
                                                                                );
                                                                        }
                                                                        catch (Exception e)
                                                                        {
                                                                            await botClient.SendTextMessageAsync(
                                                                                chatId: creatorId,
                                                                                text: e.Message
                                                                                );
                                                                        }

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
                                                                        chatId: testChatId,
                                                                        text: notification
                                                                        );
                                                                    try
                                                                    {
                                                                        await botClient.SendTextMessageAsync(
                                                                            chatId: chatId,
                                                                            text: notification
                                                                            );
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        await botClient.SendTextMessageAsync(
                                                                            chatId: creatorId,
                                                                            text: e.Message
                                                                            );
                                                                    }

                                                                }
                                                                isFound = false;
                                                            }

                                                            if (newl.Status == 0)
                                                            {

                                                                string notification = $"\U0000274C Втрата електропостачання \U0000203CМагазин № {newl.ShopId} \nЧас фіксації {newl.LogTime}";

                                                                await botClient.SendTextMessageAsync(
                                                                    chatId: testChatId,
                                                                    text: notification
                                                                    );
                                                                try
                                                                {
                                                                    await botClient.SendTextMessageAsync(
                                                                        chatId: chatId,
                                                                        text: notification
                                                                        );
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    await botClient.SendTextMessageAsync(
                                                                        chatId: creatorId,
                                                                        text: e.Message
                                                                        );
                                                                }

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
                                                    newl.isWork = false;

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

                    if (System.IO.File.Exists(pathLog))
                    {
                        System.IO.File.Delete(pathLog);
                    }

                    if (System.IO.File.Exists(pathLogFail))
                    {
                        System.IO.File.Delete(pathLogFail);
                    }

                    foreach (StatusShopModel statusShopModel in statusShopModels)
                    {
                        result += $"{statusShopModel.ShopId} {statusShopModel.Status} {statusShopModel.LogTime} {statusShopModel.isWork}\n";
                    }
                }

                result += $"{DateTime.Now}\n";

                foreach (StatusShopModel statusShopModel in failStatusShopModels)
                {
                    resultFail += $"ShopId:{statusShopModel.ShopId}\nLogTime:{statusShopModel.LogTime}\n";
                }

                await System.IO.File.AppendAllTextAsync(pathLog, result);
                await System.IO.File.AppendAllTextAsync(pathLogFail, resultFail);
            }

            catch (Exception e)
            {
                await botClient.SendTextMessageAsync(
                    chatId: creatorId,
                    text: e.Message
                    );

                return;
            }
        }

        private async Task readFromFile()
        {
            DateTime time = DateTime.Now;
            string message = $"\U0000274C Список магазинів, у яких вимкнене світло:\n";
            string id =  "";
            string logTime = "";

            if (time.Hour == 7 && time.Minute < 5 && System.IO.File.Exists(pathLogFail))
            {
                var text = System.IO.File.ReadAllLines(pathLogFail, Encoding.UTF8);

                foreach (string str in text)
                {
                    if (str.Contains("ShopId:"))
                    {
                        id = str.Substring(7);
                    }

                    if (str.Contains("LogTime:"))
                    {
                        logTime = str.Substring(8);

                        message += $"{id} - {logTime}\n";
                    }

                }

                await botClient.SendTextMessageAsync(
                    chatId: testChatId,
                    text: message
                    );

                try
                {
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: message
                        );
                }
                catch (Exception e)
                {
                    await botClient.SendTextMessageAsync(
                        chatId: creatorId,
                        text: e.Message
                        );
                }
            }
        }
    }
}