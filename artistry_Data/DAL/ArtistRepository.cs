using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace artistry_Data.DAL
{
    public class ArtistRepository:IArtistRepository, IDisposable
    {
        private Context.Context context;

        public ArtistRepository(Context.Context context)
        {
            this.context = context;
        }

        public IEnumerable<Artists> GetArtists()
        {
            return context.Artists.Include(x=>x.Country).OrderBy(x=>x.Name.Trim()).ToList();
        }

        public Artists GetArtistById(int id)
        {
            return context.Artists.Include(x => x.Country).OrderBy(x => x.Name.Trim()).Where(x=>x.Id==id).SingleOrDefault();
        }

        public IEnumerable<Artists> Search(string search)
        {
            return context.Artists.Include(x => x.Country).Where(x => x.Name.Contains(search.Trim())).ToList();
        }

        public void InsertArtist(Artists artist)
        {
            context.Artists.Add(artist);
        }

        public void UpdateArtist(Artists artist)
        {
            context.Entry(artist).State = EntityState.Modified;
        }

        public void DeleteArtist(int Id)
        {
            Artists artist = context.Artists.Find(Id);
            context.Artists.Remove(artist);
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
