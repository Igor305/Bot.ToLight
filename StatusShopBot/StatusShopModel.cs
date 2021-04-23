using System;

namespace StatusShopBot
{
    public class StatusShopModel
    {
        public int? ShopId { get; set; }
        public bool Status { get; set; }
        public DateTime? LogTime { get; set; }
    }
}
