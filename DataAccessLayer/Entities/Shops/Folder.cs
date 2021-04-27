using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class Folder
    {
        public Folder()
        {
            MediaFolders = new HashSet<MediaFolder>();
            RoleAccessToFolders = new HashSet<RoleAccessToFolder>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MediaFolder> MediaFolders { get; set; }
        public virtual ICollection<RoleAccessToFolder> RoleAccessToFolders { get; set; }
    }
}
