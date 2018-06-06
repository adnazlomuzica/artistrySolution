using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IArtworkTypeRepository:IDisposable
    {
        IEnumerable<ArtworkTypes> GetArtworkTypes();
        ArtworkTypes GetType(int typeId);
        void InsertType(ArtworkTypes type);
        void UpdateType(ArtworkTypes type);
        void DeleteType(int typeId);
        void Save();
    }
}
