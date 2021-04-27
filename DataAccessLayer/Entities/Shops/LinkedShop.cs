using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class LinkedShop
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public int FirstShopId { get; set; }
        public int SecondShopId { get; set; }

        public virtual Shop FirstShop { get; set; }
        public virtual Shop SecondShop { get; set; }
    }
}
