using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities.NetMonitoring;
using DataAccessLayer.Entities.Shops;
using DataAccessLayer.Repositories.Interfaces.NetMonitoring;
using DataAccessLayer.Repositories.Interfaces.Shops;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using Telegram.Bot;

namespace BusinessLogicLayer.Services
{
    public class BotService : IBotService
    {
        private readonly IMonitoringRepository _monitoringRepository;
        private readonly IShopsRepository _shopsRepository;
        private readonly IShopWorkTimesRepository _shopWorkTimesRepository;

        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public BotService(IMonitoringRepository monitoringRepository, IShopsRepository shopsRepository, IShopWorkTimesRepository shopWorkTimesRepository, IMapper mapper, IConfiguration configuration)
        {
            _monitoringRepository = monitoringRepository;
            _shopsRepository = shopsRepository;
            _shopWorkTimesRepository = shopWorkTimesRepository;

            _mapper = mapper;
            _configuration = configuration;
        }
        
        private static TelegramBotClient botClient;

        private static List<StatusShopModel> statusShopModels = new List<StatusShopModel>();
        private static List<StatusShopModel> failStatusShopModels = new List<StatusShopModel>();

        private static bool isStart = false;

        public async Task<List<StatusShopModel>> startBot()
        {
            if (!isStart)
            {
                isStart = true;

                botClient = new TelegramBotClient(_configuration["Bot:Token"]);
                var info = botClient.GetMeAsync().Result;

                botClient.StartReceiving();

                Timer timer = new Timer(300000);
                timer.Elapsed += async (sender, e) => await getStatus();
                timer.Start();              

                await getStatus();

            }
            return failStatusShopModels;
        }
        private async Task getStatus()
        {
            try
            {
                string not = $"BotToLight inWork";

                await botClient.SendTextMessageAsync(
                    chatId: _configuration["Bot:CreatorId"],
                    text: not
                    );

                List<Monitoring> monitorings = await _monitoringRepository.getAllLogs(21);
                List<Shop> shops = await _shopsRepository.getAllShops();
                List<ShopWorkTime> shopWorkTimes = await _shopWorkTimesRepository.getTimeToDay();

              /*  List<MonitoringModel> monitoringModels = _mapper.Map<List<Monitoring>, List<MonitoringModel>>(monitorings);
                List<ShopModel> shopModels = _mapper.Map<List<Shop>, List<ShopModel>>(shops);
                List<ShopWorkTimeModel> shopWorkTimesModels = _mapper.Map<List<ShopWorkTime>, List<ShopWorkTimeModel>>(shopWorkTimes);*/


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
                                                                            chatId: _configuration["Bot:TestChatId"],
                                                                            text: notification
                                                                            );

                                                                        /*await botClient.SendTextMessageAsync(
                                                                            chatId: _configuration["Bot:ChatId"],
                                                                            text: notification
                                                                            );*/

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
                                                                        chatId: _configuration["Bot:TestChatId"],
                                                                        text: notification
                                                                        );

                                                                    /*await botClient.SendTextMessageAsync(
                                                                        chatId: _configuration["Bot:ChatId"],
                                                                        text: notification
                                                                        );*/

                                                                }
                                                                isFound = false;
                                                            }

                                                            if (newl.Status == 0)
                                                            {

                                                                string notification = $"\U0000274C Втрата електропостачання \U0000203CМагазин № {newl.ShopId} \nЧас фіксації {newl.LogTime}";

                                                                await botClient.SendTextMessageAsync(
                                                                    chatId: _configuration["Bot:TestChatId"],
                                                                    text: notification
                                                                    );

                                                                /*await botClient.SendTextMessageAsync(
                                                                    chatId: _configuration["Bot:ChatId"],
                                                                    text: notification
                                                                    );*/

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
                }
            }

            catch
            {
                return;
            }
        }   
    }
}