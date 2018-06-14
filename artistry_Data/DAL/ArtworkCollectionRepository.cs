using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace artistry_Data.DAL
{
    public class ArtworkCollectionRepository:IArtworkCollectionRepository, IDisposable
    {
        private Context.Context context;

        public ArtworkCollectionRepository(Context.Context context)
        {
            this.context = context;
        }

        public List<ArtworkCollections> GetArtworkCollections(int id)
        {
            return context.ArtworkCollections.Include(x => x.Artwork).ThenInclude(x=>x.Artist).Include(x => x.Collection).Where(x => x.CollectionId == id).ToList();
        }

        public void InsertArtworkCollection(ArtworkCollections ac)
        {
            context.ArtworkCollections.Add(ac);
        }

        public int DeleteArtworkCollection(int id)
        {
            ArtworkCollections ac = context.ArtworkCollections.Where(x => x.Id == id).SingleOrDefault();
            int n = ac.CollectionId;
            context.ArtworkCollections.Remove(ac);

            return n;
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
