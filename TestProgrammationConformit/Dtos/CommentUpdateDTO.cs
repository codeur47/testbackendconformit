using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestProgrammationConformit.Dtos
{
    public class CommentUpdateDTO
    {
        [Required]
        public int CommentId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int EventId { get; set; }

    }
}
