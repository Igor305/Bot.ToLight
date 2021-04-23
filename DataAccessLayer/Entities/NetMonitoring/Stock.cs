#nullable disable

namespace DataAccessLayer.Entities.NetMonitoring
{
    public partial class Stock
    {
        public int Id { get; set; }
        public string StockId { get; set; }
        public string Network { get; set; }
    }
}
