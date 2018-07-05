using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace artistry_Data.DAL
{
    public class ReviewRepository : IReviewRepository, IDisposable
    {
        private Context.Context context;

        public ReviewRepository(Context.Context context)
        {
            this.context = context;
        }

        public List<Reviews> GetReviews(int id)
        {
            return context.Reviews.Include(x => x.Museum).Include(x => x.Client).Where(x => x.Museum.UserId == id).OrderByDescending(x => x.Date).ToList();
        }

        public double AverageRating(int id)
        {
            if (context.Reviews.Include(x => x.Museum).Where(x => x.Museum.UserId == id).Average(x => x.Rating) > 0)
                return context.Reviews.Include(x => x.Museum).Where(x => x.Museum.UserId == id).Average(x => x.Rating);
            return 0;
        }

        public double MonthAverageRating(int id)
        {
            if (context.Reviews.Include(x => x.Museum).Where(x => x.Museum.UserId == id && x.Date.Month == DateTime.Now.Month).Count() > 0)
                return context.Reviews.Include(x => x.Museum).Where(x => x.Museum.UserId == id && x.Date.Month == DateTime.Now.Month).Average(x => x.Rating);
            return 0;
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
