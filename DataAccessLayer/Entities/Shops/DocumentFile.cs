using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class DocumentFile
    {
        public DocumentFile()
        {
            DocumentFileContents = new HashSet<DocumentFileContent>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public string FileOriginalName { get; set; }
        public string FileGuid { get; set; }
        public int ShopDocumentId { get; set; }

        public virtual ShopDocumentFolder ShopDocument { get; set; }
        public virtual ICollection<DocumentFileContent> DocumentFileContents { get; set; }
    }
}
