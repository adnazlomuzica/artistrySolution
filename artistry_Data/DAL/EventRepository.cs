using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public class EventRepository:IEventRepository, IDisposable
    {
        private Context.Context context;

        public EventRepository(Context.Context context)
        {
            this.context = context;
        }

        public List<Events> GetEvents(int id)
        {
            return context.Events.Where(x => x.MuseumId == id).ToList();
        }

        public Events GetEventById(int id)
        {
            return context.Events.Where(x => x.Id == id).SingleOrDefault();
        }

        public void InsertEvent(Events events)
        {
            context.Events.Add(events);
        }

        public void UpdateEvent(Events events)
        {
            context.Entry(events).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void DeleteEvent(int id)
        {
            Events e = context.Events.Where(x => x.Id == id).SingleOrDefault();
            context.Events.Remove(e);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
