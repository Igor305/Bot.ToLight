using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class ShopIt
    {
        public ShopIt()
        {
            ShopItresponsibleForAssemblings = new HashSet<ShopItresponsibleForAssembling>();
            ShopItresponsibleForDisAssemblings = new HashSet<ShopItresponsibleForDisAssembling>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? EquipmentPreparationDeadline { get; set; }
        public DateTime? BaseReadyDeadline { get; set; }
        public DateTime? SettingTaskInBitrixDeadline { get; set; }
        public int? BitrixTaskNumber { get; set; }
        public int? CashboxNumber { get; set; }
        public int? BaseNumber { get; set; }
        public int? PchminiNumber { get; set; }
        public int? PrintersReceiptNumber { get; set; }
        public int? RegistrarsNumber { get; set; }
        public int? OrangeyNumber { get; set; }
        public int? RoutersNumber { get; set; }
        public DateTime? CheckInItassembling { get; set; }
        public DateTime? CheckInItdisassembling { get; set; }
        public int ShopId { get; set; }
        public int? StatusItid { get; set; }
        public string ShopItresponsibleForAssemblingNames { get; set; }
        public string ShopItresponsibleForDisAssemblingNames { get; set; }
        public string Comment { get; set; }
        public int? DoorSensor { get; set; }
        public string Horn { get; set; }
        public int? TestBox { get; set; }
        public int? UniFi { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual StatusesIt StatusIt { get; set; }
        public virtual ICollection<ShopItresponsibleForAssembling> ShopItresponsibleForAssemblings { get; set; }
        public virtual ICollection<ShopItresponsibleForDisAssembling> ShopItresponsibleForDisAssemblings { get; set; }
    }
}
