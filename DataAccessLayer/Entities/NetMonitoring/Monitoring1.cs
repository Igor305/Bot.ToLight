using System;

#nullable disable

namespace DataAccessLayer.Entities.NetMonitoring
{
    public partial class Monitoring1
    {
        public string Device { get; set; }
        public int? Stock { get; set; }
        public int? Status { get; set; }
        public string IpAddress { get; set; }
        public DateTime? LogTime { get; set; }
        public int? ResponseTime { get; set; }
        public int? Ttl { get; set; }
    }
}
