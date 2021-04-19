using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProgrammationConformit.Dtos
{
    public class CommentReadDTO
    {
        public int CommentId { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int EventId { get; set; }
    }
}
