using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class ShopHistory
    {
        public int Id { get; set; }
        public string FieldName { get; set; }
        public string FieldOldValue { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdatedByUser { get; set; }
        public string FieldNewValue { get; set; }
        public int ShopId { get; set; }
        public string TransactionId { get; set; }

        public virtual ShopHistoryNotificationDateComment ShopHistoryNotificationDateComment { get; set; }
    }
}
