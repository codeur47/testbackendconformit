using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestProgrammationConformit.Models
{
    public class Event
    {
        [Key]
        [Required]
        public int EventId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public string EventOwner { get; set; }
    }
}
