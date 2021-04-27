using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class ShopContractor1C
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public string Contractor1C { get; set; }
        public string Okpo { get; set; }
        public string Comments { get; set; }
        public int ShopId { get; set; }

        public virtual Shop Shop { get; set; }
    }
}
