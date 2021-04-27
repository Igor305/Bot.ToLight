using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class ShopHistoryNotification
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ShopHistoryId { get; set; }
        public int UserId { get; set; }
        public string ShopHistoryKeyName { get; set; }

        public virtual User User { get; set; }
    }
}
