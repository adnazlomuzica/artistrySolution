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

        public int GetLikes(int id)
        {
            return context.Likes.Where(x => x.ArtworkId == id).Count();
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
