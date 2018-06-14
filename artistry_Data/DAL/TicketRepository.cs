using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace artistry_Data.DAL
{
    public class TicketRepository:ITicketRepository, IDisposable
    {
        private Context.Context context;

        public TicketRepository(Context.Context context)
        {
            this.context = context;
        }

        public List<Tickets> GetTickets(int id)
        {
            return context.Tickets.Include(x=>x.Client).ThenInclude(x=>x.User).Include(x=>x.TicketType).ThenInclude(x=>x.Museum).Where(x => x.TicketType.Museum.UserId == id).OrderByDescending(x=>x.Date).ToList();
        }

        public int GetSum(int id)
        {
            return context.Tickets.Include(x => x.TicketType).ThenInclude(x => x.Museum).Where(x => x.TicketType.Museum.UserId == id).Sum(x=>x.Quantity);
        }

        public double GetTotal(int id)
        {
            return context.Tickets.Include(x => x.TicketType).ThenInclude(x => x.Museum).Where(x => x.TicketType.Museum.UserId == id).Sum(x => x.Total);
        }

        public double GetMonthTotal(int id)
        {
            return context.Tickets.Include(x => x.TicketType).ThenInclude(x => x.Museum).Where(x => x.TicketType.Museum.UserId == id && x.Date.Month==DateTime.Now.Month).Sum(x => x.Total);
        }

        public int GetMonthSum(int id)
        {
            return context.Tickets.Include(x => x.TicketType).ThenInclude(x => x.Museum).Where(x => x.TicketType.Museum.UserId == id && x.Date.Month==DateTime.Now.Month).Sum(x => x.Quantity);
        }

        public bool Scan(string code)
        {
            Tickets t = context.Tickets.Where(x => x.Active && x.Code == code).SingleOrDefault();
            if (t != null)
            {
                t.Active = false;
                context.SaveChanges();
                return true;
            }
            return false;
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
