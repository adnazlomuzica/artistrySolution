using artistry_Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public class MuseumRepository:IMuseumRepository, IDisposable
    {
        private Context.Context context;

        public MuseumRepository(Context.Context context)
        {
            this.context = context;
        }

        public List<Museums> GetMuseums()
        {
            return context.Museums.Include(x => x.User).Include(x=>x.MuseumType).OrderBy(x=>x.Name.Trim()).ToList();
        }

        public List<Museums> GetMuseumsByType(int typeId)
        {
            return context.Museums.Include(x => x.User).Include(x => x.MuseumType).Where(x=>x.MuseumTypeId==typeId).OrderBy(x => x.Name.Trim()).ToList();
        }

        public Museums GetMuseum(int museumId)
        {
            return context.Museums.Include(x=>x.User).Include(x => x.MuseumType).Where(x => x.Id == museumId).SingleOrDefault();
        }

        public Museums GetMuseumByAccId(int Id)
        {
            return context.Museums.Include(x => x.User).Include(x => x.MuseumType).Where(x => x.UserId==Id).SingleOrDefault();
        }

        public List<Museums> Search(string search)
        {
            return context.Museums.Include(x => x.User).Include(x => x.MuseumType).Where(x=>x.Name.Contains(search.Trim())).ToList();
        }

        public int MuseumsRegistrated()
        {
            return context.Museums.Include(x => x.User).Include(x => x.MuseumType).Where(x=>x.User.Active).Count();
        }

        public int MuseumsRegMonth()
        {
            return context.Museums.Include(x => x.User).Include(x => x.MuseumType).Where(x => x.User.Active && x.User.RegistrationDate.Month==DateTime.Now.Month).Count();
        }

        public void InsertMuseum(Museums museum)
        {
            context.Museums.Add(museum);
        }

        public void UpdateMuseum(Museums museum)
        {
            context.Entry(museum).State = EntityState.Modified;
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
