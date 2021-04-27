using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class ShopFieldsMapping
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public string FieldName { get; set; }
        public string TextFieldNameRu { get; set; }
        public string TextFieldNameUa { get; set; }
        public string FieldKeyName { get; set; }
    }
}
