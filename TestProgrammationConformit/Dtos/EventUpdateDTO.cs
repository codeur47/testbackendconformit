using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Dtos;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Dtos
{
    public class EventUpdateDTO
    {
        public int EventId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<CommentReadDTO> Comments { get; set; }

        public string EventOwner { get; set; }
    }
}
