using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.Areas.Administrator.ViewModels
{
    public class ChartsVM
    {
        public List<WeeklyAppLogReview> weeklyAppLogReviews { get; set; }
        public List<MonthlyUserRegistration> monthlyUserRegistrations { get; set; }
    }
}
