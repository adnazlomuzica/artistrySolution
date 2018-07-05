using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace artistry_Data.DAL
{
    public class ImageRepository:IImageRepository, IDisposable
    {
        private Context.Context context;

        public ImageRepository(Context.Context context)
        {
            this.context = context;
        }

        public IEnumerable<Images> GetArtistImages(int id)
        {
            return context.Images.Where(x => x.ArtistId == id).ToList();
        }

        public IEnumerable<Images> GetMuseumImages(int id)
        {
            return context.Images.Where(x => x.MuseumId == id).ToList();
        }

        public Images GetMuseumImage(int id)
        {
            return context.Images.Where(x => x.MuseumId == id && x.Primary).SingleOrDefault();
        }

        public IEnumerable<Images> GetArtworkImages(int id)
        {
            return context.Images.Where(x => x.ArtworkId == id).ToList();
        }

        public IEnumerable<Images> GetNewsImages(int id)
        {
            return context.Images.Where(x => x.NewsId == id).ToList();
        }

        public Images GetArtworkImage(int id)
        {
            return context.Images.Where(x => x.ArtworkId == id && x.Primary).SingleOrDefault();
        }

        public Images GetArtistImage(int id)
        {
            return context.Images.Where(x => x.ArtistId == id && x.Primary).SingleOrDefault();
        }

        public Images GetNewsImage(int id)
        {
            return context.Images.Where(x => x.NewsId == id && x.Primary).SingleOrDefault();
        }

        public async Task<Images> GetImageById(int id)
        {
            return await context.Images.FindAsync(id);
        }

        public Images GetImage(int id)
        {
            return context.Images.Find(id);
        }

        public void InsertImage(Images image)
        {
            context.Images.Add(image);
        }

        public void UpdateImage(Images image)
        {
            context.Entry(image).State = EntityState.Modified;
        }

        public int DeleteImage(int id)
        {
            Images i = context.Images.Find(id);
            int artistId = Convert.ToInt32(i.ArtistId);

            context.Images.Remove(i);

            return artistId;
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
