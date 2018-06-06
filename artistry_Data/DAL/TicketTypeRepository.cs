using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace artistry_Data.DAL
{
    public class TicketTypeRepository:ITicketTypeRepository, IDisposable
    {
        private Context.Context context;

        public TicketTypeRepository(Context.Context context)
        {
            this.context = context;
        }

        public IEnumerable<TicketTypes> GetTicketTypes(int id)
        {
            return context.TicketTypes.Where(x => x.MuseumId == id).Include(x => x.Museum).Include(x=>x.Currency).OrderBy(x=>x.Type.Trim()).ToList();
        }

        public TicketTypes GetType(int id)
        {
            return context.TicketTypes.Where(x => x.Id == id).SingleOrDefault();
        }

        public void DeleteType(int id)
        {
            TicketTypes t = context.TicketTypes.Find(id);
            context.TicketTypes.Remove(t);
        }

        public void InsertType(TicketTypes type)
        {
            context.TicketTypes.Add(type);
        }

        public void UpdateType(TicketTypes type)
        {
            context.Entry(type).State = EntityState.Modified;
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
