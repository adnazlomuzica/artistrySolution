using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace artistry_Data.DAL
{
    public class WorkingHourRepository:IWorkingHourRepository, IDisposable
    {
        private Context.Context context;

        public WorkingHourRepository(Context.Context context)
        {
            this.context = context;
        }

        public IEnumerable<WorkingHours> GetWorkingHours(int id)
        {
            return context.WorkingHours.Where(x => x.MuseumId == id).Include(x=>x.Museum).OrderBy(x => x.Day).ToList();
        }

        public void InsertHours(WorkingHours hours)
        {
            context.WorkingHours.Add(hours);
        }

        public void UpdateHours(WorkingHours hours)
        {
            context.Entry(hours).State = EntityState.Modified;
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
