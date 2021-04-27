using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class Language
    {
        public Language()
        {
            RegionsLocalizations = new HashSet<RegionsLocalization>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CreatedByUserId { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual ICollection<RegionsLocalization> RegionsLocalizations { get; set; }
    }
}
