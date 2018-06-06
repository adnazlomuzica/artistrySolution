using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IArtistRepository:IDisposable
    {
        IEnumerable<Artists> GetArtists();
        IEnumerable<Artists> Search(string search);
        Artists GetArtistById(int id);
        void InsertArtist(Artists artist);
        void UpdateArtist(Artists artist);
        void DeleteArtist(int Id);
        void Save();
    }
}
