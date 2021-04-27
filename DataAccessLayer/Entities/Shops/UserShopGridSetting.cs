using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class UserShopGridSetting
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public string Settings { get; set; }
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public string GridName { get; set; }

        public virtual User User { get; set; }
    }
}
