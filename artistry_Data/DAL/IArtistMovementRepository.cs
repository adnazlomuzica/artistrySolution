using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IArtistMovementRepository:IDisposable
    {
        IEnumerable<ArtistMovements> GetArtistMovements();
        IEnumerable<ArtistMovements> GetArtistMovementsByArtist(int id);
        void InsertArtistMovement(ArtistMovements artistMovements);
        void UpdateArtistMovement(ArtistMovements artistMovements);
        void Save();
    }
}
