using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface ILikesRepository:IDisposable
    {
        int GetLikes(int id);
        bool IsLiked(int userId, int artworkId);
        void InsertLike(Likes like);
        void DeleteLike(int usrId,int id);
        void Save();
    }
}
