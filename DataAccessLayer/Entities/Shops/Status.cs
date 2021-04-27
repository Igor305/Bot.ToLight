using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class Status
    {
        public Status()
        {
            RoleAccessToStatuses = new HashSet<RoleAccessToStatus>();
            Shops = new HashSet<Shop>();
            StatusesLocalizations = new HashSet<StatusesLocalization>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int? ParentId { get; set; }

        public virtual ICollection<RoleAccessToStatus> RoleAccessToStatuses { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<StatusesLocalization> StatusesLocalizations { get; set; }
    }
}
