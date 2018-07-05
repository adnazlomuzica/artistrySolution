using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace artistry_Data.DAL
{
    public class NewsRepository:INewsRepository,IDisposable
    {
        private Context.Context context;

        public NewsRepository(Context.Context context)
        {
            this.context = context;
        }

        public List<News> GetAllNews()
        {
            return context.News.Include(x => x.Museum).OrderByDescending(x => x.Date).ToList();
        }

        public List<News> Search(string search)
        {
            return context.News.Include(x => x.Museum).Where(x=>x.Title.Contains(search) || x.Text.Contains(search)).OrderByDescending(x => x.Date).ToList();
        }

        public List<News> GetNews(int id)
        {
            return context.News.Include(x=>x.Museum).Where(x=>x.MuseumId==id).OrderByDescending(x=>x.Date).ToList();
        }

        public  List<News> GetLatest()
        {
            return context.News.Include(x=>x.Museum).OrderByDescending(x => x.Date).Take(3).ToList();
        }

        public News GetNewsById(int id)
        {
            return context.News.Include(x => x.Museum).Where(x => x.Id == id).SingleOrDefault();
        }

        public void InsertNews(News news)
        {
            context.News.Add(news);
        }

        public void UpdateNews(News news)
        {
            context.Entry(news).State = EntityState.Modified;
        }

        public void DeleteNews(int id)
        {
            News n = context.News.Find(id);
            context.News.Remove(n);
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
