using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class User
    {
        public User()
        {
            ShopHistoryNotifications = new HashSet<ShopHistoryNotification>();
            UserShopGridSettings = new HashSet<UserShopGridSetting>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<ShopHistoryNotification> ShopHistoryNotifications { get; set; }
        public virtual ICollection<UserShopGridSetting> UserShopGridSettings { get; set; }
    }
}
