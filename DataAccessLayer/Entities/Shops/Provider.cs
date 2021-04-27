using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class Provider
    {
        public Provider()
        {
            ShopProviders = new HashSet<ShopProvider>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public string SiteLink { get; set; }
        public string AccountLink { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ShopProvider> ShopProviders { get; set; }
    }
}
