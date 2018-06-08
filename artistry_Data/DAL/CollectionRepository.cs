using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace artistry_Data.DAL
{
    public class CollectionRepository:ICollectionRepository, IDisposable
    {
        private Context.Context context;

        public CollectionRepository(Context.Context context)
        {
            this.context = context;
        }

        public List<Collections> GetCollections(int id)
        {
            return context.Collections.Include(x => x.Museum).Include(x => x.Image).Where(x=>x.MuseumId==id).OrderBy(x=>x.Active).ToList();
        }

        public Collections GetCollectionById(int id)
        {
            return context.Collections.Include(x => x.Museum).Include(x => x.Image).Where(x => x.Id == id).SingleOrDefault();
        }
        public void InsertCollection(Collections collection)
        {
            context.Collections.Add(collection);
        }

        public void UpdateCollection(Collections collection)
        {
            context.Entry(collection).State = EntityState.Modified;
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
