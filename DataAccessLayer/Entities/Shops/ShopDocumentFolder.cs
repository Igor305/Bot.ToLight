using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class ShopDocumentFolder
    {
        public ShopDocumentFolder()
        {
            DocumentFiles = new HashSet<DocumentFile>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public int ShopId { get; set; }
        public int DocumentFolderId { get; set; }
        public int? DocumentId { get; set; }

        public virtual DocumentFolder Document { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual ICollection<DocumentFile> DocumentFiles { get; set; }
    }
}
