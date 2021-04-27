using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class BitrixResponse
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public int? ShopNumber { get; set; }
        public string TaskNumber { get; set; }
        public string Comments { get; set; }
        public string TaskReason { get; set; }
        public int ShopId { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
