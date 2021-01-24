using System;
using System.ComponentModel.DataAnnotations.Schema;
using MyCleanCode.Domain.Common;

namespace MyCleanCode.Domain.Entities
{
    [Table("Order")]
    public class Order : AuditableEntity
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int Total { get; set; }
        public DateTime Placed { get; set; }
        public bool Paid { get; set; }
    }
}