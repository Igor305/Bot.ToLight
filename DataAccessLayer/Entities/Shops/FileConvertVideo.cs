using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class FileConvertVideo
    {
        public FileConvertVideo()
        {
            Files = new HashSet<File>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? ImportStartTime { get; set; }
        public bool Converted { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}
