using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IEventRepository:IDisposable
    {
        List<Events> GetEvents(int id);
        Events GetEventById(int id);
        void InsertEvent(Events events);
        void UpdateEvent(Events events);
        void DeleteEvent(int id);
        void Save();
    }
}
