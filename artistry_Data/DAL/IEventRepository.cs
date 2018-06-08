using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IEventRepository:IDisposable
    {
        void InsertEvent(Events events);
        void Save();
    }
}
