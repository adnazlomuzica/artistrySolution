using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace artistry_Data.DAL
{
    public class ArtistMovementRepository:IArtistMovementRepository, IDisposable
    {
        private Context.Context context;

        public ArtistMovementRepository(Context.Context context)
        {
            this.context = context;
        }

        public IEnumerable<ArtistMovements> GetArtistMovementsByArtist(int id)
        {
            return context.ArtistMovements.Where(x => x.ArtistId == id).Include(x=>x.Style).Include(x=>x.Artist).OrderBy(x=>x.Style.Name.Trim()).ToList();
        }

        public IEnumerable<ArtistMovements> GetArtistMovements()
        {
            return context.ArtistMovements.Include(x => x.Style).Include(x => x.Artist).OrderBy(x => x.Style.Name.Trim()).ToList();
        }

        public void InsertArtistMovement(ArtistMovements artistMovements)
        {
            context.ArtistMovements.Add(artistMovements);
        }

        public void UpdateArtistMovement(ArtistMovements artistMovements)
        {
            context.Entry(artistMovements).State = EntityState.Modified;
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
