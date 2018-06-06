using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IImageRepository:IDisposable
    {
        IEnumerable<Images> GetArtistImages(int id);
        IEnumerable<Images> GetMuseumImages(int id);
        Task<Images> GetImageById(int id);
        Images GetImage(int id);
        void InsertImage(Images image);
        void UpdateImage(Images image);
        int DeleteImage(int id);
        void Save();
    }
}
