using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Data.Models;
using artistry_Web.Areas.Administrator.ViewModels;
using artistry_Web.Helper;
using artistry_Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace artistry_Web.Areas.Administrator.Controllers
{
    [Authorization(true, false, false)]
    [Area("Administrator")]
    [Route("Administrator/[controller]")]
    public class HomeController : Controller
    {
        private readonly IMuseumRepository museumRepository;
        private readonly IUserRepository userRepository;
        private readonly IAppLogRepository appLogRepository;

        public HomeController(Context context)
        {
            this.museumRepository = new MuseumRepository(context);
            this.userRepository = new UserRepository(context);
            this.appLogRepository = new AppLogRepository(context);
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            InfoVM model = new InfoVM();

            model.MuseumsRegistrated = museumRepository.MuseumsRegistrated();
            model.MuseumsRegMonth = museumRepository.MuseumsRegMonth();
            model.TicketsRevenue = 0;
            model.TicketsRevenueMonth = 0;
            model.TicketsSale = 0;
            model.TicketsSaleMonth = 0;
            model.UsersRegistrated = 0;
            model.UsersRegMonth = 0;
            model.ActiveMuseums = 0;
            model.InactiveMuseums = 0;
            Random rnd = new Random();

            model.museumTicketSales = new List<MuseumTicketSale>();

            IEnumerable<Museums> museums = museumRepository.GetMuseums();

            foreach (Museums x in museums)
            {
                model.museumTicketSales.Add(new MuseumTicketSale
                {
                    Museum = x.Name,
                    Quantity = rnd.Next(10)
                });

                if (x.User.Active)
                    model.ActiveMuseums++;
                else
                    model.InactiveMuseums++;
            }
            model.TotalMuseumTicketSales = model.museumTicketSales.Select(x=>x.Quantity).Sum();

            return View(model);
        }

        [HttpGet("Charts")]
        public PartialViewResult Charts()
        {
            ChartsVM model = new ChartsVM();
            model.monthlyUserRegistrations = new List<MonthlyUserRegistration>();
            model.weeklyAppLogReviews = new List<WeeklyAppLogReview>();

            int userId = Autentification.GetLoggedUser(HttpContext).Id;

            IEnumerable<UserAccounts> users = userRepository.GetUsers(userId);

            int startMonth = DateTime.Now.AddMonths(1).Month;
            int endMonth = DateTime.Now.Month;

            users = users.Where(x => (x.RegistrationDate.Month >= startMonth && x.RegistrationDate.Year == DateTime.Now.AddYears(-1).Year) ||
                     (x.RegistrationDate.Month <= endMonth && x.RegistrationDate.Year == DateTime.Now.Year)).ToList();

            
            model.monthlyUserRegistrations.Add(new MonthlyUserRegistration
            {
                Number = (12-startMonth)-(DateTime.Now.Month+startMonth),
                Month = "January",
                Quantity = users.Where(y => y.RegistrationDate.Month == 1).Count()
            });
            model.monthlyUserRegistrations.Add(new MonthlyUserRegistration
            {
                Number = (12 - startMonth) - (DateTime.Now.AddMonths(-1).Month + startMonth),
                Month = "February",
                Quantity = users.Where(y => y.RegistrationDate.Month == 2).Count()
            });
            model.monthlyUserRegistrations.Add(new MonthlyUserRegistration
            {
                Number = (12 - startMonth) - (DateTime.Now.AddMonths(-2).Month + startMonth),
                Month = "March",
                Quantity = users.Where(y => y.RegistrationDate.Month == 3).Count()
            });
            model.monthlyUserRegistrations.Add(new MonthlyUserRegistration
            {
                Number = (12 - startMonth) - (DateTime.Now.AddMonths(-3).Month + startMonth),
                Month = "April",
                Quantity = users.Where(y => y.RegistrationDate.Month == 4).Count()
            });
            model.monthlyUserRegistrations.Add(new MonthlyUserRegistration
            {
                Number = (12 - startMonth) - (DateTime.Now.AddMonths(-4).Month + startMonth),
                Month = "May",
                Quantity = users.Where(y => y.RegistrationDate.Month == 5).Count()
            });
            model.monthlyUserRegistrations.Add(new MonthlyUserRegistration
            {
                Number = (12 - startMonth) - (DateTime.Now.AddMonths(-5).Month + startMonth),
                Month = "June",
                Quantity = users.Where(y => y.RegistrationDate.Month == 6).Count()
            });
            model.monthlyUserRegistrations.Add(new MonthlyUserRegistration
            {
                Number = (12 - startMonth) - (DateTime.Now.AddMonths(-6).Month + startMonth),
                Month = "July",
                Quantity = users.Where(y => y.RegistrationDate.Month == 7).Count()
            });
            model.monthlyUserRegistrations.Add(new MonthlyUserRegistration
            {
                Number = (12 - startMonth) - (DateTime.Now.AddMonths(-7).Month + startMonth),
                Month = "August",
                Quantity = users.Where(y => y.RegistrationDate.Month == 8).Count()
            });
            model.monthlyUserRegistrations.Add(new MonthlyUserRegistration
            {
                Number = (12 - startMonth) - (DateTime.Now.AddMonths(-8).Month + startMonth),
                Month = "September",
                Quantity = users.Where(y => y.RegistrationDate.Month == 9).Count()
            });
            model.monthlyUserRegistrations.Add(new MonthlyUserRegistration
            {
                Number = (12 - startMonth) - (DateTime.Now.AddMonths(-9).Month + startMonth),
                Month = "October",
                Quantity = users.Where(y => y.RegistrationDate.Month == 10).Count()
            });
            model.monthlyUserRegistrations.Add(new MonthlyUserRegistration
            {
                Number = (12 - startMonth) - (DateTime.Now.AddMonths(-10).Month + startMonth),
                Month = "November",
                Quantity = users.Where(y => y.RegistrationDate.Month == 11).Count()
            });
            model.monthlyUserRegistrations.Add(new MonthlyUserRegistration
            {
                Number = (12 - startMonth) - (DateTime.Now.AddMonths(-11).Month + startMonth),
                Month = "December",
                Quantity = users.Where(y => y.RegistrationDate.Month == 12).Count()
            });

            model.monthlyUserRegistrations=model.monthlyUserRegistrations.OrderBy(x => x.Number).ToList();
            IEnumerable<AppLogs> appLogs = appLogRepository.GetThisWeeksLogs();

            int startweek = DateTime.Now.AddDays(-6).DayOfYear;
            int endweek = DateTime.Now.DayOfYear;        

            for(int i=startweek; i <= endweek; i++)
            {
                WeeklyAppLogReview a = new WeeklyAppLogReview();
                if (appLogs.Where(x => x.Logged.DayOfYear == i).Count()>0){
                    foreach(AppLogs log in appLogs.Where(x => x.Logged.DayOfYear == i))
                    {
                       a.WeekDay = log.Logged.DayOfWeek.ToString();
                       a.Quantity = appLogs.Where(y => y.Logged.DayOfYear == i).Count();
                       model.weeklyAppLogReviews.Add(a);
                       break;
                    }                  
                }
                else
                {
                    int year = DateTime.Now.Year;
                    DateTime date = new DateTime(year, 1, 1).AddDays(i - 1);
                    a.WeekDay = date.DayOfWeek.ToString();
                    a.Quantity = 0;
                    model.weeklyAppLogReviews.Add(a);
                }
            }                        
            return PartialView("Charts", model);
        }
    }
}
