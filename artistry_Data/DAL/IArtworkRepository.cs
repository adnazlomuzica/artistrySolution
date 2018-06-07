using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IArtworkRepository:IDisposable
    {
        List<Artworks> GetArtworksByMuseum(int id);
        List<Artworks> GetArtworksByArtist(int id);
        List<Artworks> Search(string search, int id);
        Artworks GetArtworkById(int id);
        void InsertArtwork(Artworks artwork);
        void UpdateArtwork(Artworks artwork);
        void Save();
    }
}
