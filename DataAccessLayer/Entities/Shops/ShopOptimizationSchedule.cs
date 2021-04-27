using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class ShopOptimizationSchedule
    {
        public int Id { get; set; }
        public DateTime? DateFrom { get; set; }
        public string Action { get; set; }
        public int ShopId { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
