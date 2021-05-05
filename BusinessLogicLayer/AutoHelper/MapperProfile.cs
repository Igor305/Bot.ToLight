using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities.NetMonitoring;
using DataAccessLayer.Entities.Shops;
using System.Collections.Generic;

namespace BusinessLogicLayer.AutoHelper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<List<Monitoring>, List<MonitoringModel>>();
            CreateMap<List<Shop>, List<ShopModel>>();
            CreateMap<List<ShopWorkTime>, List<ShopWorkTimeModel>>();
        }
    }
}
