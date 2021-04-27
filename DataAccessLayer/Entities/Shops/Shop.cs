using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class Shop
    {
        public Shop()
        {
            BitrixResponses = new HashSet<BitrixResponse>();
            LinkedShopFirstShops = new HashSet<LinkedShop>();
            LinkedShopSecondShops = new HashSet<LinkedShop>();
            MediaFolders = new HashSet<MediaFolder>();
            Notifications = new HashSet<Notification>();
            ShopContactPeople = new HashSet<ShopContactPerson>();
            ShopContractor1Cs = new HashSet<ShopContractor1C>();
            ShopDocumentFolders = new HashSet<ShopDocumentFolder>();
            ShopInstallersDevelopments = new HashSet<ShopInstallersDevelopment>();
            ShopOptimizationSchedules = new HashSet<ShopOptimizationSchedule>();
            ShopProviders = new HashSet<ShopProvider>();
            ShopRents = new HashSet<ShopRent>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Schedule { get; set; }
        public double TotalArea { get; set; }
        public double TradingArea { get; set; }
        public double UtilityRoomArea { get; set; }
        public int? ShopNumber { get; set; }
        public DateTime? OpenFrom { get; set; }
        public int? StreetId { get; set; }
        public int StatusId { get; set; }
        public int? RegionId { get; set; }
        public int? CityId { get; set; }
        public string WorkPhoneNumber { get; set; }
        public int? ShopRegionId { get; set; }
        public string CreatedByUserId { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string Address { get; set; }
        public string AddressComment { get; set; }
        public int? DistrictId { get; set; }
        public int? ShopWorkTimeId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime? AdvertisingInstallation { get; set; }
        public DateTime? ClosedFrom { get; set; }
        public string DevelopmentDepartmentCoordinatorComments { get; set; }
        public DateTime? DateOfStudy { get; set; }
        public string DistrinutionDepartmentComments { get; set; }
        public string Itequipment { get; set; }
        public string Logistics { get; set; }
        public string PriceList { get; set; }
        public int RevenuePlan { get; set; }
        public DateTime? StartWorkForClosed { get; set; }
        public DateTime? StartWorkForOpen { get; set; }
        public bool? Terminal { get; set; }
        public int? ShopHeatingTypeId { get; set; }
        public int? ShopObjectComplexityId { get; set; }
        public int? ShopSecurityId { get; set; }
        public byte[] TerritorialManagerId { get; set; }
        public byte[] StaffManagerId { get; set; }
        public byte[] RegionalManagerId { get; set; }
        public byte[] DevelopmentDepartmentManagerId { get; set; }
        public byte[] DevelopmentDepartmentCoordinatorId { get; set; }
        public byte[] DeputyAdministratorId { get; set; }
        public byte[] AdministratorId { get; set; }
        public byte[] PrivateEntrepreneurId { get; set; }
        public string ShopWorkTimeString { get; set; }
        public string Conditioners { get; set; }
        public string Ledpanels { get; set; }
        public bool? LandlordLoyalty { get; set; }
        public string LandlordLoyaltyComments { get; set; }
        public string DifficultyTtunloading { get; set; }
        public string Repair { get; set; }

        public virtual City City { get; set; }
        public virtual District District { get; set; }
        public virtual Region Region { get; set; }
        public virtual ShopHeatingType ShopHeatingType { get; set; }
        public virtual ShopObjectComplexity ShopObjectComplexity { get; set; }
        public virtual ShopRegion ShopRegion { get; set; }
        public virtual ShopSecurity ShopSecurity { get; set; }
        public virtual ShopWorkTime ShopWorkTime { get; set; }
        public virtual Status Status { get; set; }
        public virtual Street Street { get; set; }
        public virtual ShopIt ShopIt { get; set; }
        public virtual ICollection<BitrixResponse> BitrixResponses { get; set; }
        public virtual ICollection<LinkedShop> LinkedShopFirstShops { get; set; }
        public virtual ICollection<LinkedShop> LinkedShopSecondShops { get; set; }
        public virtual ICollection<MediaFolder> MediaFolders { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<ShopContactPerson> ShopContactPeople { get; set; }
        public virtual ICollection<ShopContractor1C> ShopContractor1Cs { get; set; }
        public virtual ICollection<ShopDocumentFolder> ShopDocumentFolders { get; set; }
        public virtual ICollection<ShopInstallersDevelopment> ShopInstallersDevelopments { get; set; }
        public virtual ICollection<ShopOptimizationSchedule> ShopOptimizationSchedules { get; set; }
        public virtual ICollection<ShopProvider> ShopProviders { get; set; }
        public virtual ICollection<ShopRent> ShopRents { get; set; }
    }
}
