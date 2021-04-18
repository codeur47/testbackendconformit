using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProgrammationConformit.Dtos
{
    public class CommentReadDTO
    {
        public int CommentId { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public int EventFK { get; set; }
    }
}
