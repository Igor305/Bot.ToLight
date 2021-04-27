using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class Region
    {
        public Region()
        {
            Districts = new HashSet<District>();
            RegionsLocalizations = new HashSet<RegionsLocalization>();
            Shops = new HashSet<Shop>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual ICollection<District> Districts { get; set; }
        public virtual ICollection<RegionsLocalization> RegionsLocalizations { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
    }
}
