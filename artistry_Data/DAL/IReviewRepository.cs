using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IReviewRepository:IDisposable
    {
        List<Reviews> GetReviews(int id);
        double AverageRating(int id);
        double MonthAverageRating(int id);
    }
}
