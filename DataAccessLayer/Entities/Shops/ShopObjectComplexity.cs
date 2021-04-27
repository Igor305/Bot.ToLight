using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class ShopObjectComplexity
    {
        public ShopObjectComplexity()
        {
            Shops = new HashSet<Shop>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public string Complexity { get; set; }
        public int? CameraCount { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }
    }
}
