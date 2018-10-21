using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Data.Dbo;
using artistry_Data.Models;
using artistry_Web.Helper;
using artistry_Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using Stripe;
using static artistry_Web.Startup;

namespace artistry_Web.Controllers
{
    [Route("[controller]/[action]")]
    public class MuseumController : Controller
    {
        private readonly IMuseumRepository museumRepository;
        private readonly IArtworkRepository artworkRepository;
        private readonly IImageRepository imageRepository;
        private readonly ICollectionRepository collectionRepository;
        private readonly IEventRepository eventRepository;
        private readonly INewsRepository newsRepository;
        private readonly ITicketTypeRepository tickettypeRepository;
        private readonly ITicketRepository ticketRepository;
        private readonly IWorkingHourRepository workinghoursRepository;
        private readonly IReviewRepository reviewRepository;
        private readonly IUserRepository userRepository;
        private readonly IClientRepository clientRepository;
        private readonly IArtworkCollectionRepository artworkcollectionRepository;

        public MuseumController(Context context)
        {
            this.museumRepository = new MuseumRepository(context);
            this.artworkRepository = new ArtworkRepository(context);
            this.imageRepository = new ImageRepository(context);
            this.collectionRepository = new CollectionRepository(context);
            this.eventRepository = new EventRepository(context);
            this.newsRepository = new NewsRepository(context);
            this.tickettypeRepository = new TicketTypeRepository(context);
            this.ticketRepository = new TicketRepository(context);
            this.workinghoursRepository = new WorkingHourRepository(context);
            this.reviewRepository = new ReviewRepository(context);
            this.userRepository = new UserRepository(context);
            this.clientRepository = new ClientRepository(context);
            this.artworkcollectionRepository = new ArtworkCollectionRepository(context);
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            List<MuseumInfoVM> list = museumRepository.GetShortDescription();

            const int PageSize = 12;
            var count = list.Count();
            if (page == 1)
                list = list.Skip(0).Take(PageSize).ToList();

            else
                list = list.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            if (count <= PageSize)
                ViewBag.MaxPage = 1;
            else
            {
                if (count % PageSize == 0)
                {
                    ViewBag.MaxPage = (count / PageSize);
                }
                else
                {
                    ViewBag.MaxPage = (count / PageSize) + 1;
                }
            }
            ViewBag.Page = page;
            ViewBag.NextPage = page + 1;

            foreach (MuseumInfoVM x in list)
            {
                x.Image = imageRepository.GetMuseumImage(x.Id);
                if (x.Image != null)
                {
                    x.ImageId = x.Image.Id;
                }

            }
            return View(list);
        }

        [HttpGet]
        public IActionResult Search(string search, int page = 1)
        {
            List<Museums> list = new List<Museums>();
            if (search != null)
            {
                list = museumRepository.Search(search);
            }
            else
            {
                list = museumRepository.GetMuseums();
            }
            List<MuseumVM> model = new List<MuseumVM>();

            const int PageSize = 12;
            var count = list.Count();
            if (page == 1)
                list = list.Skip(0).Take(PageSize).ToList();

            else
                list = list.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            if (count <= PageSize)
                ViewBag.MaxPage = 1;
            else
            {
                if (count % PageSize == 0)
                {
                    ViewBag.MaxPage = (count / PageSize);
                }
                else
                {
                    ViewBag.MaxPage = (count / PageSize) + 1;
                }
            }
            ViewBag.Page = page;
            ViewBag.NextPage = page + 1;

            foreach (Museums x in list)
            {
                MuseumVM vm = new MuseumVM();
                vm.Id = x.Id;
                vm.Address = x.Address;
                vm.Name = x.Name;
                vm.Image = imageRepository.GetMuseumImage(x.Id);
                if (vm.Image != null)
                {
                    vm.ImageId = vm.Image.Id;
                }
                model.Add(vm);
            }
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Museums m = museumRepository.GetMuseum(id);
            MuseumVM model = new MuseumVM();

            model.Id = m.Id;
            model.Address = m.Address;
            model.Description = m.Description;
            model.Email = m.Email;
            if (model.Image != null)
            {
                model.ImageId = model.Image.Id;
            }

            model.Images = imageRepository.GetMuseumImages(id);
            model.Latitude = m.Latitude;
            model.Longitude = m.Longitude;
            model.Image = imageRepository.GetMuseumImage(m.Id);
            model.Name = m.Name;
            model.OpeningYear = m.OpeningYear;
            model.Phone = m.Phone;
            model.TicketSelling = m.OnlineTickets;
            model.Type = m.MuseumType.Name;
            model.UserId = m.UserId;
            List<Artworks> artworks = artworkRepository.GetArtworksByMuseum(m.Id);

            model.Artworks = new List<ArtworkVM>();
            foreach (Artworks a in artworks)
            {
                ArtworkVM vm = new ArtworkVM();
                vm.Artist = a.Artist.Name;
                vm.ArtworkType = a.ArtworkType.Name;
                vm.ArtworkTypeId = a.ArtworkTypeId;
                vm.Country = a.Country.Name;
                vm.Id = a.Id;
                vm.Image = imageRepository.GetArtworkImage(a.Id);
                if (vm.Image != null)
                {
                    vm.ImageId = vm.Image.Id;
                }
                vm.Name = a.Name;
                vm.MuseumId = a.MuseumId;
                model.Artworks.Add(vm);
            }

            List<News> news = newsRepository.GetNews(m.Id);
            model.News = new List<NewsVM>();
            foreach (News x in news)
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
            model.Collections = collectionRepository.GetCollections(m.Id);
            model.Events = eventRepository.GetEvents(m.Id);
            model.TicketTypes = tickettypeRepository.GetTicketTypes(m.Id);
            model.WorkingHours = workinghoursRepository.GetWorkingHours(m.Id);
            model.Review = new Reviews();
            model.Review.MuseumId = m.Id;
            return View("Details", model);
        }

        [HttpPost]
        public IActionResult Review(Reviews review)
        {
            if (Autentification.GetLoggedUser(HttpContext) != null)
            {
                Reviews r = new Reviews();
                r.MuseumId = review.MuseumId;
                //r.Rating = Int32.Parse(rate);
                r.Rating = review.Rating;
                r.Note = review.Note;
                //r.Note = komentar;
                r.Date = DateTime.Now;
                UserAccounts u = Autentification.GetLoggedUser(HttpContext);
                r.ClientId = clientRepository.GetClientByUserId(u.Id).Id;

                reviewRepository.AddReview(r);
                reviewRepository.Save();
                return RedirectToAction("Details", r.MuseumId);
            }

            else
                return RedirectToAction("Index", "Autentification");
        }

        public IActionResult Collection(int id)
        {
            Collections c = collectionRepository.GetCollectionById(id);

            CollectionVM model = new CollectionVM();
            model.Artworks = new List<ArtworkVM>();
            List<ArtworkCollections> artworks = artworkcollectionRepository.GetArtworkCollections(c.Id);
            foreach (ArtworkCollections art in artworks)
            {
                ArtworkVM vm = new ArtworkVM();
                vm.Id = art.ArtworkId;
                vm.Name = art.Artwork.Name;
                vm.Artist = art.Artwork.Artist.Name;
                vm.Image = imageRepository.GetArtworkImage(art.ArtworkId);
                vm.Museum = art.Artwork.Museum.Name;
                if (vm.Image != null)
                {
                    vm.ImageId = vm.Image.Id;
                }
                vm.Liked = false;
                model.Artworks.Add(vm);
            }

            model.Image = c.Image;
            if (model.Image != null)
            {
                model.ImageId = model.Image.Id;
            }

            model.Description = c.Description;
            model.Id = c.Id;
            model.MuseumId = c.MuseumId;
            model.Name = c.Name;

            return View("Collection", model);
        }

        [HttpPost]
        [Authorization(false, false, true)]
        public IActionResult Charge(string stripeEmail, string stripeToken, Tickets ticket)
        {

            var myCharge = new StripeChargeCreateOptions();

            // always set these properties
            myCharge.Amount = (int)ticket.Total * 100;
            myCharge.Currency = "eur";

            myCharge.ReceiptEmail = stripeEmail;
            myCharge.Description = "Test Charge";
            myCharge.SourceTokenOrExistingSourceId = stripeToken;
            myCharge.Capture = true;


            var chargeService = new StripeChargeService();
            StripeCharge stripeCharge = chargeService.Create(myCharge);


            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            GuidString = GuidString.Replace("/", "");

            if (GuidString.Length > 15)
                ticket.Code = GuidString.Substring(0, 15);
            else
                ticket.Code = GuidString;
            ticket.Active = true;
            ticketRepository.Add(ticket);
            ticketRepository.Save();
            return View("Charge", GuidString);
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            UserAccounts u = Autentification.GetLoggedUser(HttpContext);

            if (u == null)
                return RedirectToAction("Index", "Autentification");

            else
            {
                Tickets ticket = new Tickets();
                ticket.TicketTypeId = id;

                TicketTypes type = tickettypeRepository.GetType(id);

                ticket.Date = DateTime.Now;
                ticket.Quantity = 1;
                ticket.Seen = false;
                ticket.Active = false;
                ticket.Code = "";
                ticket.ClientId = clientRepository.GetClientByUserId(u.Id).Id;
                ticket.Quantity = 1;
                ticket.Total = type.Price;

                ViewData["type"] = type.Type;
                ViewData["total"] = ticket.Total * 100;


                return View("Buy", ticket);
            }
        }
    }
}
