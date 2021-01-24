using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCleanCode.Domain.Entities
{
    [Table("Event")]
    public class Event
    {
        public int EventId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int Price { get; set; }
        [Required]
        [StringLength(50)]
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}