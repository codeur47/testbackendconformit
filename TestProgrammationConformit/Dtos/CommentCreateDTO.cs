using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestProgrammationConformit.Dtos
{
    public class CommentCreateDTO
    {
        [Required]
        public int CommentId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int EventFK { get; set; }

    }
}
