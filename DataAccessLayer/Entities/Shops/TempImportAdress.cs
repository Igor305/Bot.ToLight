using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class TempImportAdress
    {
        public int Id { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
