using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IArtworkCollectionRepository:IDisposable
    {
        List<ArtworkCollections> GetArtworkCollections(int id);
        void InsertArtworkCollection(ArtworkCollections ac);
        int DeleteArtworkCollection(int id);
        void Save();
    }
}
