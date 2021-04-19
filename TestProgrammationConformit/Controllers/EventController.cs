using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Services;
using TestProgrammationConformit.Dtos;
using TestProgrammationConformit.Models;
using AutoMapper;

namespace TestProgrammationConformit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetEventById")]
        public ActionResult<EventReadDTO> GetEventById(int id)
        {
            var eventItem = _eventService.GetEventById(id);
            if (eventItem != null)
            {
                return Ok(_mapper.Map<EventReadDTO>(eventItem));
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventReadDTO>> GetAllEvents()
        {
            return Ok(_mapper.Map< IEnumerable<EventReadDTO>>(_eventService.GetAllEvents()));
        }

        [HttpPost]
        public ActionResult<EventReadDTO> CreateEvent(EventCreateDTO eventCreateDTO)
        {
            var eventModel = _mapper.Map<Event>(eventCreateDTO);

            _eventService.CreateEvent(eventModel);
            _eventService.SaveChanges();

            var eventReadDto = _mapper.Map<EventReadDTO>(eventModel);

            return CreatedAtRoute(nameof(GetEventById), new { Id = eventReadDto.EventId }, eventReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEvent(int id, EventUpdateDTO eventUpdateDTO)
        {
            var eve = _eventService.GetEventById(id);
            if (eve == null)
            {
                return NotFound();
            }
            _mapper.Map(eventUpdateDTO, eve);

            _eventService.UpdateEvent(eve);

            _eventService.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEvent(int id)
        {
            var eve = _eventService.GetEventById(id);
            if (eve == null)
            {
                return NotFound();
            }
            _eventService.DeleteEvent(id);
            _eventService.SaveChanges();

            return NoContent();
        }

    }
}
