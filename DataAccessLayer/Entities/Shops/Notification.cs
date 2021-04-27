using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class Notification
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ShopId { get; set; }
        public string NotificationType { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
