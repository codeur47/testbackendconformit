using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Dtos;
using TestProgrammationConformit.Infrastructures;
using AutoMapper;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Services
{
    public class EventService : IEventService
    {

        private readonly ConformitContext _conformitContext;
        private readonly ICommentService _commentService;

        public EventService(ConformitContext conformitContext, ICommentService commentService)
        {
            _conformitContext = conformitContext;
            _commentService = commentService;
        }

        public void CreateEvent(Event ev)
        {
            if(ev == null)
                throw new ArgumentNullException(nameof(ev));

            _conformitContext.Event.Add(ev);
        }

        public void DeleteEvent(int id)
        {
            _conformitContext.Event.Remove(_conformitContext.Event.FirstOrDefault(c => c.EventId == id));
        }

        public Event GetEventById(int id)
        {
            return _conformitContext.Event.FirstOrDefault(c => c.EventId == id);
        }

        public bool SaveChanges()
        {
            return (_conformitContext.SaveChanges() >= 0);
        }

        public void UpdateEvent(Event ev)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Event> IEventService.GetAllEvents()
        {
            IEnumerable<Comment> comments = _commentService.GetAllComments();
            IEnumerable<Event> eves = _conformitContext.Event.ToList();

            foreach(Event ev in eves)
            {
                foreach (Comment com in comments)
                {
                    if(ev.EventId == com.EventId)
                    {
                        ev.Comments.Add(com);
                    }
                        
                }
            }

            return eves;
        }
    }
}
