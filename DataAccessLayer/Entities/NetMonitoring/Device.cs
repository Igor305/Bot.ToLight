#nullable disable

namespace DataAccessLayer.Entities.NetMonitoring
{
    public partial class Device
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string DevicePrefiks { get; set; }
    }
}
