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

        public List<Artworks> GetArtworks()
        {
            return context.Artworks.Include(x => x.Artist).Include(x => x.ArtworkType).Include(x => x.Country).Include(x => x.Material).Include(x => x.Museum).Include(x => x.Style).OrderBy(x=>x.Name).ToList();
        }

        public List<Artworks> GetArtworksByMuseum(int id)
        {
            return context.Artworks.Include(x => x.Artist).Include(x => x.ArtworkType).Include(x => x.Country).Include(x => x.Material).Include(x => x.Museum).Include(x => x.Style).Where(x => x.MuseumId == id).OrderBy(x=>x.Name).ToList();
        }

        public List<Artworks> GetArtworksByArtist(int id)
        {
            return context.Artworks.Include(x => x.Artist).Include(x => x.ArtworkType).Include(x => x.Country).Include(x => x.Material).Include(x => x.Museum).Include(x => x.Style).Where(x => x.ArtistId == id).OrderBy(x=>x.Name).ToList();
        }

        public List<Artworks> GetArtworksByType(int id)
        {
            return context.Artworks.Include(x => x.Artist).Include(x => x.ArtworkType).Include(x => x.Country).Include(x => x.Material).Include(x => x.Museum).Include(x => x.Style).Where(x => x.ArtworkTypeId == id).OrderBy(x => x.Name).ToList();
        }
        public List<Artworks> Search(string search, int? id)
        {
            if(id!=null)
               return context.Artworks.Include(x => x.Artist).Include(x => x.ArtworkType).Include(x => x.Country).Include(x => x.Material).Include(x => x.Museum).Include(x => x.Style).Where(x => x.Name.Contains(search.Trim()) && x.MuseumId==id).OrderBy(x=>x.Name).ToList();

          return context.Artworks.Include(x => x.Artist).Include(x => x.ArtworkType).Include(x => x.Country).Include(x => x.Material).Include(x => x.Museum).Include(x => x.Style).Where(x => x.Name.Contains(search.Trim())).OrderBy(x => x.Name).ToList();

        }

        public Artworks GetArtworkById(int id)
        {
            return context.Artworks.Include(x => x.Artist).Include(x => x.ArtworkType).Include(x => x.Country).Include(x => x.Material).Include(x => x.Museum).Include(x => x.Style).Where(x=>x.Id==id).SingleOrDefault();
        }

        public List<Artworks> GetTop6()
        {
            List<int> likes = new List<int>();
            List<Likes> l = context.Likes.ToList();
            List<Artworks> artworks = new List<Artworks>();

            List<Artworks> list = context.Artworks.Include(x=>x.Artist).ToList();

            foreach (Artworks a in list)
            {
                    int like = l.Where(x => x.ArtworkId == a.Id).Count();
                    likes.Add(like);
            }

            if (likes.Count() >= 6)
                likes = likes.OrderBy(x => x).Take(6).ToList();

            foreach (Artworks a in list)
            {
                if (l.Where(x => x.ArtworkId == a.Id).Count() > 0)
                {
                    foreach (double d in likes)
                    {
                        if (l.Where(x => x.ArtworkId == a.Id).Count() == d)
                            artworks.Add(a);
                    }
                }
            }

            if (artworks.Count() < 6)
            {
                foreach (Artworks a in list)
                {
                    if (artworks.Count() < 6 && artworks.Where(x => x.Id == a.Id).Count() == 0)
                    {
                        artworks.Add(a);
                    }
                }
            }
            return artworks;
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
