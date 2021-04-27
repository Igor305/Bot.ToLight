using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Entities.Shops
{
    public partial class AccessDepartmentForm
    {
        public AccessDepartmentForm()
        {
            Fields = new HashSet<Field>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public string KeyName { get; set; }
        public string AccessDepartmentKeyName { get; set; }

        public virtual ICollection<Field> Fields { get; set; }
    }
}
