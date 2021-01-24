using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MyCleanCode.Domain.Common;

namespace MyCleanCode.Domain.Entities
{
    [Table("Category")]
    public class Category : AuditableEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}