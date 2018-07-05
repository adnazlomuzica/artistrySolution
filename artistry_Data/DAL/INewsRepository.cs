using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface INewsRepository:IDisposable
    {
        List<News> GetAllNews();
        List<News> Search(string search);
        List<News> GetNews(int id);
        List<News> GetLatest();
        News GetNewsById(int id);
        void InsertNews(News news);
        void UpdateNews(News news);
        void DeleteNews(int id);
        void Save();
    }
}
