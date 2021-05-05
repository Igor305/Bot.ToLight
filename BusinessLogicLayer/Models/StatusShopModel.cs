using System;

namespace BusinessLogicLayer.Models
{
    public class StatusShopModel
    {
        public int? ShopId { get; set; }
        public int? Status { get; set; }
        public DateTime? LogTime { get; set; }
        public bool isWork { get; set; }
    }
}
