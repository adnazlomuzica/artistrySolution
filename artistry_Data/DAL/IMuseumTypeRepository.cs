using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IMuseumTypeRepository:IDisposable
    {
        IEnumerable<MuseumTypes> GetMuseumTypes();
        MuseumTypes GetMuseumType(int typeId);
        void InsertMuseumType(MuseumTypes type);
        void UpdateMuseumType(MuseumTypes type);
        void DeleteMuseumType(int typeId);
        void Save();
    }
}
