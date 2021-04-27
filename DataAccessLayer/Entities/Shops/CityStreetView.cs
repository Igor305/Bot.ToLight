using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class CityStreetView
    {
        public int CityId { get; set; }
        public string StreetName { get; set; }
        public int LanguageId { get; set; }
    }
}
