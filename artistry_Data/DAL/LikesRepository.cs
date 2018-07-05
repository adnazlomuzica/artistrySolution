using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public class LikesRepository:ILikesRepository, IDisposable
    {
        private Context.Context context;

        public LikesRepository(Context.Context context)
        {
            this.context = context;
        }

        public bool IsLiked(int userId, int artworkId)
        {
            if (context.Likes.Where(x => x.ClientId == userId && x.ArtworkId == artworkId).Count() > 0)
                return true;
            return false;
        }
        public int GetLikes(int id)
        {
            return context.Likes.Where(x => x.ArtworkId == id).Count();
        }

        public void InsertLike(Likes like)
        {
            context.Likes.Add(like);
        }

        public void DeleteLike(int usrId,int id)
        {
            Likes like = context.Likes.Where(x=>x.ArtworkId==id&&x.ClientId==usrId).SingleOrDefault();
            context.Likes.Remove(like);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
