using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class ShopRegion
    {
        public ShopRegion()
        {
            ShopRegionLocalizations = new HashSet<ShopRegionLocalization>();
            Shops = new HashSet<Shop>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual ICollection<ShopRegionLocalization> ShopRegionLocalizations { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
    }
}
