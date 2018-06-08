using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface INewsRepository:IDisposable
    {
        List<News> GetNews(int id);
        News GetNewsById(int id);
        void InsertNews(News news);
        void UpdateNews(News news);
        void DeleteNews(int id);
        void Save();
    }
}
