using artistry_Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public class MuseumTypeRepository:IMuseumTypeRepository, IDisposable
    {
        private Context.Context context;

        public MuseumTypeRepository(Context.Context context)
        {
            this.context = context;
        }

        public IEnumerable<MuseumTypes> GetMuseumTypes()
        {
            return context.MuseumTypes.OrderBy(x => x.Name.Trim()).ToList();
        }

        public MuseumTypes GetMuseumType(int typeId)
        {
            return context.MuseumTypes.Where(x => x.Id == typeId).SingleOrDefault();
        }

        public void InsertMuseumType(MuseumTypes type)
        {
            context.MuseumTypes.Add(type);
        }

        public void UpdateMuseumType(MuseumTypes type)
        {
            context.Entry(type).State = EntityState.Modified;
        }

        public void DeleteMuseumType(int typeId)
        {
            MuseumTypes type = context.MuseumTypes.Find(typeId);
            context.MuseumTypes.Remove(type);
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
