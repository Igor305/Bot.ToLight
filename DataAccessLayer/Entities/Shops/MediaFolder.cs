using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class MediaFolder
    {
        public MediaFolder()
        {
            Files = new HashSet<File>();
            InverseParentFolder = new HashSet<MediaFolder>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public string Name { get; set; }
        public int ShopId { get; set; }
        public int FolderId { get; set; }
        public int? ParentFolderId { get; set; }

        public virtual Folder Folder { get; set; }
        public virtual MediaFolder ParentFolder { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<MediaFolder> InverseParentFolder { get; set; }
    }
}
