using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class AccessType
    {
        public AccessType()
        {
            RoleAccessToCatalogs = new HashSet<RoleAccessToCatalog>();
            RoleAccessToDocumentFolders = new HashSet<RoleAccessToDocumentFolder>();
            RoleAccessToFields = new HashSet<RoleAccessToField>();
            RoleAccessToFolders = new HashSet<RoleAccessToFolder>();
            RoleAccessToStatuses = new HashSet<RoleAccessToStatus>();
            RoleAccesses = new HashSet<RoleAccess>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string KeyName { get; set; }
        public string CreatedByUserId { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual ICollection<RoleAccessToCatalog> RoleAccessToCatalogs { get; set; }
        public virtual ICollection<RoleAccessToDocumentFolder> RoleAccessToDocumentFolders { get; set; }
        public virtual ICollection<RoleAccessToField> RoleAccessToFields { get; set; }
        public virtual ICollection<RoleAccessToFolder> RoleAccessToFolders { get; set; }
        public virtual ICollection<RoleAccessToStatus> RoleAccessToStatuses { get; set; }
        public virtual ICollection<RoleAccess> RoleAccesses { get; set; }
    }
}
