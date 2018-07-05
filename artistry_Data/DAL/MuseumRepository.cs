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

        public List<Museums> GetTop3()
        {
            List<double> avg = new List<double>();
            List<Reviews> r = context.Reviews.ToList();
            List<Museums> museums = new List<Museums>();

            List<Museums> list = context.Museums.ToList();

            foreach (Museums m in list)
            {
                if (r.Where(x => x.MuseumId == m.Id).Count() > 0)
                {
                    double average = r.Where(x => x.MuseumId == m.Id).Average(x => x.Rating);
                    avg.Add(average);
                }
            }

            if(avg.Count()>=3)
            avg=avg.OrderBy(x => x).Take(3).ToList(); 

            foreach (Museums m in list)
            {
                if (r.Where(x => x.MuseumId == m.Id).Count() > 0)
                {
                    foreach (double d in avg)
                    {
                        if (r.Where(x => x.MuseumId == m.Id).Average(x => x.Rating) == d)
                            museums.Add(m);
                    }
                }
            }

            if (museums.Count() < 3)
            {
                foreach(Museums m in list)
                {
                    if (museums.Count() < 3 && museums.Where(x=>x.Id==m.Id).Count()==0)
                    {
                        museums.Add(m);
                    }
                }
            }
            return museums;
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
