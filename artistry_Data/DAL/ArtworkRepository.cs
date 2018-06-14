using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace artistry_Data.DAL
{
    public class ArtworkRepository:IArtworkRepository, IDisposable
    {
        private Context.Context context;

        public ArtworkRepository(Context.Context context)
        {
            this.context = context;
        }

        public List<Artworks> GetArtworksByMuseum(int id)
        {
            return context.Artworks.Include(x => x.Artist).Include(x => x.ArtworkType).Include(x => x.Country).Include(x => x.Material).Include(x => x.Museum).Include(x => x.Style).Where(x => x.MuseumId == id).OrderBy(x=>x.Name).ToList();
        }

        public List<Artworks> GetArtworksByArtist(int id)
        {
            return context.Artworks.Include(x => x.Artist).Include(x => x.ArtworkType).Include(x => x.Country).Include(x => x.Material).Include(x => x.Museum).Include(x => x.Style).Where(x => x.ArtistId == id).OrderBy(x=>x.Name).ToList();
        }

        public List<Artworks> Search(string search, int id)
        {
            return context.Artworks.Include(x => x.Artist).Include(x => x.ArtworkType).Include(x => x.Country).Include(x => x.Material).Include(x => x.Museum).Include(x => x.Style).Where(x => x.Name.Contains(search.Trim()) && x.MuseumId==id).OrderBy(x=>x.Name).ToList();
        }

        public Artworks GetArtworkById(int id)
        {
            return context.Artworks.Include(x => x.Artist).Include(x => x.ArtworkType).Include(x => x.Country).Include(x => x.Material).Include(x => x.Museum).Include(x => x.Style).Where(x=>x.Id==id).SingleOrDefault();
        }

        public void InsertArtwork(Artworks artwork)
        {
            context.Artworks.Add(artwork);
        }

        public void UpdateArtwork(Artworks artwork)
        {
            context.Entry(artwork).State = EntityState.Modified;
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
