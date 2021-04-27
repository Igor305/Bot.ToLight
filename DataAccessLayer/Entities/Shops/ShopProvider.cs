using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class ShopProvider
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public string ContractNumber { get; set; }
        public string IssuedOn { get; set; }
        public string AccountLogin { get; set; }
        public string Password { get; set; }
        public string Ip { get; set; }
        public bool? IsPublic { get; set; }
        public int? Speed { get; set; }
        public bool? IsMacBinding { get; set; }
        public string ConnectionType { get; set; }
        public string Note { get; set; }
        public int ShopId { get; set; }
        public int ProviderId { get; set; }

        public virtual Provider Provider { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
