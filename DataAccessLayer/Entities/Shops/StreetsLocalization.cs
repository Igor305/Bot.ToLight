using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class StreetsLocalization
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public int StreetId { get; set; }
        public string CreatedByUserId { get; set; }
        public int LanguageId { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual Street Street { get; set; }
    }
}
