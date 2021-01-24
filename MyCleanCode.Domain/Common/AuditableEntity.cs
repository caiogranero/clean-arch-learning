using System;
using System.ComponentModel;

namespace MyCleanCode.Domain.Common
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [DefaultValue(false)]
        public bool Inactive { get; set; }
    }
}