using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProgrammationConformit.Dtos
{
    public class EventReadDTO
    {
        public int EventId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<CommentReadDTO> Comments { get; set; }

        public string EventOwner { get; set; }
    }
}
