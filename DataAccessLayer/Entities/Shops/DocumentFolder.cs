using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class DocumentFolder
    {
        public DocumentFolder()
        {
            InverseParentDocumentFolder = new HashSet<DocumentFolder>();
            RoleAccessToDocumentFolders = new HashSet<RoleAccessToDocumentFolder>();
            ShopDocumentFolders = new HashSet<ShopDocumentFolder>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public string Name { get; set; }
        public int? ParentDocumentFolderId { get; set; }

        public virtual DocumentFolder ParentDocumentFolder { get; set; }
        public virtual ICollection<DocumentFolder> InverseParentDocumentFolder { get; set; }
        public virtual ICollection<RoleAccessToDocumentFolder> RoleAccessToDocumentFolders { get; set; }
        public virtual ICollection<ShopDocumentFolder> ShopDocumentFolders { get; set; }
    }
}
