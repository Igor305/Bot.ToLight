using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class File
    {
        public File()
        {
            FileContents = new HashSet<FileContent>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public int MediaFolderId { get; set; }
        public string FileGuid { get; set; }
        public string FileOriginalName { get; set; }
        public string Description { get; set; }
        public int? FileConvertVideoId { get; set; }

        public virtual FileConvertVideo FileConvertVideo { get; set; }
        public virtual MediaFolder MediaFolder { get; set; }
        public virtual ICollection<FileContent> FileContents { get; set; }
    }
}
