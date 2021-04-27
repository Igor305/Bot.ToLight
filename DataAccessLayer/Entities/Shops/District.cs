using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class District
    {
        public District()
        {
            Cities = new HashSet<City>();
            DistrictsLocalizations = new HashSet<DistrictsLocalization>();
            Shops = new HashSet<Shop>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RegionId { get; set; }
        public string CreatedByUserId { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<DistrictsLocalization> DistrictsLocalizations { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
    }
}
