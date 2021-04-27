using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class DocumentFileContent
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public byte[] Content { get; set; }
        public bool IsPdfforDocx { get; set; }
        public int DocumentFileId { get; set; }

        public virtual DocumentFile DocumentFile { get; set; }
    }
}
