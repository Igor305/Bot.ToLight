using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class ShopSecurity
    {
        public ShopSecurity()
        {
            Shops = new HashSet<Shop>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public string Security { get; set; }
        public DateTime? SetupDate { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }
    }
}
