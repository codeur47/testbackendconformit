using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Models;
using TestProgrammationConformit.Dtos;

namespace TestProgrammationConformit.Services
{
    public interface IEventService
    {
        bool SaveChanges();

        Event GetEventById(int id);
        IEnumerable<Event> GetAllEvents();
        void CreateEvent(Event ev);
        void UpdateEvent(Event ev);
        void DeleteEvent(int id);
    }
}
