using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class ShopGridView
    {
        public int Id { get; set; }
        public int? ShopNumber { get; set; }
        public DateTime? OpenFrom { get; set; }
        public double TotalArea { get; set; }
        public double TradingArea { get; set; }
        public double UtilityRoomArea { get; set; }
        public int? StreetId { get; set; }
        public string StreetName { get; set; }
        public string Address { get; set; }
        public string AddressComment { get; set; }
        public int? CityId { get; set; }
        public int? LanguageId { get; set; }
        public string CityName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string ParentStatusName { get; set; }
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int? RegionId { get; set; }
        public string RegionName { get; set; }
        public int? ShopRegionId { get; set; }
        public string ShopRegionName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? ShopWorkTimeId { get; set; }
        public DateTime? StartWorkForClosed { get; set; }
        public DateTime? StartWorkForOpen { get; set; }
        public DateTime? ClosedFrom { get; set; }
        public string DevelopmentDepartmentCoordinatorComments { get; set; }
        public string Logistics { get; set; }
        public string PriceList { get; set; }
        public int RevenuePlan { get; set; }
        public string Itequipment { get; set; }
        public bool? Terminal { get; set; }
        public DateTime? DateOfStudy { get; set; }
        public DateTime? AdvertisingInstallation { get; set; }
        public string DistrinutionDepartmentComments { get; set; }
        public string WorkPhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ShopWorkTimeString { get; set; }
        public int? ShopSecurityId { get; set; }
        public int? ShopHeatingTypeId { get; set; }
        public int? ShopObjectComplexityId { get; set; }
        public string Conditioners { get; set; }
        public string Ledpanels { get; set; }
        public bool? LandlordLoyalty { get; set; }
        public string LandlordLoyaltyComments { get; set; }
        public string DifficultyTtunloading { get; set; }
        public string Repair { get; set; }
        public byte[] PrivateEntrepreneurId { get; set; }
        public string PrivateEntrepreneurName { get; set; }
        public byte[] TerritorialManagerId { get; set; }
        public string TerritorialManagerName { get; set; }
        public bool? TerritorialManagerIsWorking { get; set; }
        public byte[] RegionalManagerId { get; set; }
        public string RegionalManagerName { get; set; }
        public bool? RegionalManagerIsWorking { get; set; }
        public byte[] DevelopmentDepartmentManagerId { get; set; }
        public string DevelopmentDepartmentManagerName { get; set; }
        public bool? DevelopmentDepartmentManagerIsWorking { get; set; }
        public byte[] DevelopmentDepartmentCoordinatorId { get; set; }
        public string DevelopmentDepartmentCoordinatorName { get; set; }
        public bool? DevelopmentDepartmentCoordinatorIsWorking { get; set; }
        public byte[] StaffManagerId { get; set; }
        public string StaffManagerName { get; set; }
        public bool? StaffManagerIsWorking { get; set; }
        public byte[] AdministratorId { get; set; }
        public string AdministratorName { get; set; }
        public bool? AdministratorIsWorking { get; set; }
        public byte[] DeputyAdministratorId { get; set; }
        public string DeputyAdministratorName { get; set; }
        public bool? DeputyAdministratorIsWorking { get; set; }
        public string StatusItname { get; set; }
        public int? ShopItid { get; set; }
        public DateTime? CheckInItassembling { get; set; }
        public DateTime? CheckInItdisassembling { get; set; }
        public int? StatusItid { get; set; }
        public DateTime? EquipmentPreparationDeadline { get; set; }
        public DateTime? BaseReadyDeadline { get; set; }
        public DateTime? SettingTaskInBitrixDeadline { get; set; }
        public int? BitrixTaskNumber { get; set; }
        public int? CashboxNumber { get; set; }
        public int? BaseNumber { get; set; }
        public int? PchminiNumber { get; set; }
        public int? PrintersReceiptNumber { get; set; }
        public int? RegistrarsNumber { get; set; }
        public int? OrangeyNumber { get; set; }
        public int? RoutersNumber { get; set; }
        public string ShopItresponsibleForAssemblingNames { get; set; }
        public string ShopItresponsibleForDisAssemblingNames { get; set; }
        public int? UniFi { get; set; }
        public int? DoorSensor { get; set; }
        public int? TestBox { get; set; }
        public string Horn { get; set; }
        public string Comment { get; set; }
        public string ShopSecurity { get; set; }
        public string ShopObjectComplexity { get; set; }
        public string ShopHeatingType { get; set; }
    }
}
