using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class City
    {
        public City()
        {
            CitiesLocalizations = new HashSet<CitiesLocalization>();
            Shops = new HashSet<Shop>();
            Streets = new HashSet<Street>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int DistrictId { get; set; }
        public string CreatedByUserId { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual District District { get; set; }
        public virtual ICollection<CitiesLocalization> CitiesLocalizations { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<Street> Streets { get; set; }
    }
}
