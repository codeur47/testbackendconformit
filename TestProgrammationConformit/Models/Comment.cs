using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace TestProgrammationConformit.Models
{
    public class Comment
    {
        [Key]
        [Required]
        public int CommentId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}
