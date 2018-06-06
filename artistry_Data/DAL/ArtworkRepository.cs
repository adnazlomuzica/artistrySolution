using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public class ArtworkRepository:IArtworkRepository, IDisposable
    {
        private Context.Context context;

        public ArtworkRepository(Context.Context context)
        {
            this.context = context;
        }

        public void InsertArtwork(Artworks artwork)
        {
            context.Artworks.Add(artwork);
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
