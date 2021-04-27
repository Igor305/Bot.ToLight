using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class DistrictCityView
    {
        public int DistrictId { get; set; }
        public string CityName { get; set; }
        public int LanguageId { get; set; }
    }
}
