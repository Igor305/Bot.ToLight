using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class ShopHeatingType
    {
        public ShopHeatingType()
        {
            Shops = new HashSet<Shop>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public string HeatingType { get; set; }
        public int? Power { get; set; }
        public int? Limit { get; set; }
        public string Counters { get; set; }
        public string Comments { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }
    }
}
