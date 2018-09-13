using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using artistry_Web.Models;
using artistry_Data.Context;
using artistry_Data.Models;
using artistry_Web.Helper;
using Microsoft.AspNetCore.Diagnostics;
using artistry_Data.DAL;
using artistry_Web.ViewModels;

namespace artistry_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMuseumRepository museumRepository;
        private readonly IAdministratorRepository adminRepository;
        private readonly INewsRepository newsRepository;
        private readonly IArtworkRepository artworkRepository;
        private readonly IImageRepository imageRepository;

        public HomeController(Context context)
        {
            this.museumRepository = new MuseumRepository(context);
            this.adminRepository=new AdministratorRepository(context);
            this.artworkRepository = new ArtworkRepository(context);
            this.imageRepository = new ImageRepository(context);
            this.newsRepository = new NewsRepository(context);
        }
        public IActionResult Index()
        {
            UserAccounts u = Autentification.GetLoggedUser(HttpContext);
            Administrators admin=null;
            Museums museum=null;

            if (u != null)
            {
                if (adminRepository.GetAdministrator(u.Id) != null)
                    admin = adminRepository.GetAdministrator(u.Id);
                if (museumRepository.GetMuseumByAccId(u.Id) != null)
                    museum = museumRepository.GetMuseumByAccId(u.Id);
            }

            if (admin != null)
            {
                return RedirectToAction("Index", "Home", new { area = "Administrator" });
            }

            else if (museum != null)
            {
                return RedirectToAction("Index", "Home", new { area = "Moderator" });
            }

            else
            {
                HomeVM model = new HomeVM();

                List<Museums> list = museumRepository.GetTop3();
                model.Museums = new List<MuseumVM>();
                model.Artworks = new List<ArtworkVM>();
                model.News = new List<NewsVM>();
                List<Artworks> artworks = artworkRepository.GetTop6();
                List<News> news = newsRepository.GetLatest();

                foreach (Museums x in list)
                {
                    MuseumVM m = new MuseumVM();
                    m.Id = x.Id;
                    m.Description = x.Description;
                    m.Image = imageRepository.GetMuseumImage(x.Id);
                    m.Name = x.Name;
                    if (m.Image != null)
                    {
                        m.ImageId = m.Image.Id;
                    }
                    model.Museums.Add(m);
                }

                foreach(Artworks x in artworks)
                {
                    ArtworkVM a = new ArtworkVM();
                    a.Id = x.Id;
                    a.Name = x.Name;
                    a.Artist = x.Artist.Name;
                    a.Museum = x.Museum.Name;
                    a.Image = imageRepository.GetArtworkImage(x.Id);
                    if (a.Image != null)
                    {
                        a.ImageId = a.Image.Id;
                    }
                    model.Artworks.Add(a);
                }

                foreach(News x in news)
                {
                    NewsVM n = new NewsVM();
                    n.Id = x.Id;
                    n.Date = x.Date;
                    n.Image = imageRepository.GetNewsImage(x.Id);
                    if (n.Image != null)
                    {
                        n.ImageId = n.Image.Id;
                    }
                    n.Museum = x.Museum.Name;
                    n.Subtitle = x.SubTitle;
                    n.Text = x.Text;
                    n.Title = x.Title;
                    model.News.Add(n);
                }

                return View("Index", model);
            }

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Route("/Error")]
        public IActionResult Error()
        {
            // Get the details of the exception that occurred
          
                // TODO: Do something with the exception
                // Log it with Serilog?
                // Send an e-mail, text, fax, or carrier pidgeon?  Maybe all of the above?
                // Whatever you do, be careful to catch any exceptions, otherwise you'll end up with a blank page and throwing a 500

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
