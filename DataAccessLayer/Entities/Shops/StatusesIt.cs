using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class StatusesIt
    {
        public StatusesIt()
        {
            ShopIts = new HashSet<ShopIt>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public string Name { get; set; }
        public string SystemKey { get; set; }

        public virtual ICollection<ShopIt> ShopIts { get; set; }
    }
}
