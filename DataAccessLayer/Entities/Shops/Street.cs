using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class Street
    {
        public Street()
        {
            Shops = new HashSet<Shop>();
            StreetsLocalizations = new HashSet<StreetsLocalization>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CityId { get; set; }
        public string CreatedByUserId { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<StreetsLocalization> StreetsLocalizations { get; set; }
    }
}
