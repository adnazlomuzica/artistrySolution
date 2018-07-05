using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IArtworkRepository:IDisposable
    {
        List<Artworks> GetArtworks();
        List<Artworks> GetArtworksByMuseum(int id);
        List<Artworks> GetArtworksByArtist(int id);
        List<Artworks> GetArtworksByType(int id);
        List<Artworks> Search(string search, int? id);
        List<Artworks> GetTop6();
        Artworks GetArtworkById(int id);
        void InsertArtwork(Artworks artwork);
        void UpdateArtwork(Artworks artwork);
        void Save();
    }
}
