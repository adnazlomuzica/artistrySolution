using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface ICollectionRepository:IDisposable
    {
        List<Collections> GetCollections(int id);
        Collections GetCollectionById(int id);
        void InsertCollection(Collections collection);
        void UpdateCollection(Collections collection);
        void Save();
    }
}
