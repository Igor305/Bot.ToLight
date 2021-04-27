using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class ShopHistoryNotificationDateComment
    {
        public int Id { get; set; }
        public int ShopHistoryId { get; set; }
        public string Comment { get; set; }

        public virtual ShopHistory ShopHistory { get; set; }
    }
}
