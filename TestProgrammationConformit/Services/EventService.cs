using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Dtos;
using TestProgrammationConformit.Infrastructures;
using AutoMapper;

namespace TestProgrammationConformit.Services
{
    public class EventService : IEventService
    {

        private readonly ConformitContext _conformitContext;
        private readonly IMapper _mapper;

        public EventService(ConformitContext conformitContext, IMapper mapper)
        {
            _conformitContext = conformitContext;
            _mapper = mapper;
        }

        public IEnumerable<EventReadDTO> GetAllEvents()
        {
            return _mapper.Map<IEnumerable<EventReadDTO>>(_conformitContext.Event.ToList());
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
