using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class RoleAccessToField
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RoleId { get; set; }
        public int FieldId { get; set; }
        public int AccessTypeId { get; set; }
        public string CreatedByUserId { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual AccessType AccessType { get; set; }
        public virtual Field Field { get; set; }
        public virtual Role Role { get; set; }
    }
}
