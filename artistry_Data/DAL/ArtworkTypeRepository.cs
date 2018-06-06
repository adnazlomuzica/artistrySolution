using artistry_Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public class ArtworkTypeRepository:IArtworkTypeRepository, IDisposable
    {
        private Context.Context context;

        public ArtworkTypeRepository(Context.Context context)
        {
            this.context = context;
        }

        public IEnumerable<ArtworkTypes> GetArtworkTypes()
        {
            return context.ArtworkTypes.OrderBy(x => x.Name.Trim()).ToList();
        }

        public ArtworkTypes GetType(int typeId)
        {
            return context.ArtworkTypes.Where(x => x.Id == typeId).SingleOrDefault();
        }

        public void InsertType(ArtworkTypes type)
        {
            context.ArtworkTypes.Add(type);
        }

        public void UpdateType(ArtworkTypes type)
        {
            context.Entry(type).State = EntityState.Modified;
        }

        public void DeleteType(int typeId)
        {
            ArtworkTypes type = context.ArtworkTypes.Find(typeId);
            context.ArtworkTypes.Remove(type);
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
