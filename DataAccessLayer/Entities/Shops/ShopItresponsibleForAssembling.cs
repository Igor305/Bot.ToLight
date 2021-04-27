using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class ShopItresponsibleForAssembling
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public int ShopItid { get; set; }
        public byte[] EmployeeDirectoryId { get; set; }

        public virtual ShopIt ShopIt { get; set; }
    }
}
