using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Data.Models;
using artistry_Web.Helper;
using artistry_Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace artistry_Web.Controllers
{
    [Route("[controller]/[action]")]
    public class ArtistController : Controller
    {
        private readonly IArtistRepository artistRepository;
        private readonly IImageRepository imageRepository;
        private readonly IArtworkRepository artworkRepository;
        private readonly IArtistMovementRepository stylesRepository;
        private readonly ILikesRepository likesRepository;
        private readonly IClientRepository clientRepository;

        public ArtistController(Context context)
        {
            this.artistRepository = new ArtistRepository(context);
            this.imageRepository = new ImageRepository(context);
            this.artworkRepository = new ArtworkRepository(context);
            this.stylesRepository = new ArtistMovementRepository(context);
            this.likesRepository = new LikesRepository(context);
            this.clientRepository = new ClientRepository(context);
        }

        [HttpGet]
        public IActionResult Index(int page=1)
        {
            IEnumerable<Artists> list = artistRepository.GetArtists();
            List<ArtistVM> model = new List<ArtistVM>();
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
                    ViewBag.MaxPage = (count / PageSize)+1;
                }
            }
            ViewBag.Page = page;
            ViewBag.NextPage = page + 1;

            foreach (Artists x in list)
            {
                ArtistVM a = new ArtistVM();
                a.Id = x.Id;
                a.Name = x.Name;
                a.Biography = x.Biography;
                a.Born = x.Born;
                a.Country = x.Country.Name;
                a.Died = x.Died;
                a.Image = imageRepository.GetArtistImage(x.Id);
                if (a.Image != null)
                {
                    a.ImageId = a.Image.Id;
                }
                a.Images = imageRepository.GetArtistImages(x.Id);
                a.Artworks = new List<ArtworkVM>();
                a.Styles = new List<string>();
                model.Add(a);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Search(string search, int page=1)
        {
            IEnumerable<Artists> artist;
            if (search != null)
            {
                artist = artistRepository.Search(search);
            }
            else
            {
                artist = artistRepository.GetArtists();
            }

            List<ArtistVM> model = new List<ArtistVM>();

            const int PageSize = 12;

            var count = artist.Count();

            if (page == 1)
            {
                artist = artist.Skip(0).Take(PageSize).ToList();
            }
            else
            {
                artist = artist.Skip((page - 1) * PageSize).Take(PageSize).ToList();
            }

            if (count <= PageSize)
            {
                ViewBag.MaxPage = 1;
            }
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

            foreach (Artists x in artist)
            {
                ArtistVM a = new ArtistVM();
                a.Id = x.Id;
                a.Name = x.Name;
                a.Biography = x.Biography;
                a.Born = x.Born;
                a.Country = x.Country.Name;
                a.Died = x.Died;
                a.Image = imageRepository.GetArtistImage(x.Id);
                if (a.Image != null)
                {
                    a.ImageId = a.Image.Id;
                }
                a.Images = imageRepository.GetArtistImages(x.Id);
                a.Artworks = new List<ArtworkVM>();
                a.Styles = new List<string>();
                model.Add(a);
            }

            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Artists a = artistRepository.GetArtistById(id);

            ArtistVM model = new ArtistVM();
            model.Artworks = new List<ArtworkVM>();
            model.Styles = new List<string>();
            List<Artworks> artworks = artworkRepository.GetArtworksByArtist(a.Id);
            foreach (Artworks art in artworks)
            {
                ArtworkVM vm = new ArtworkVM();
                vm.Id = art.Id;
                vm.Name = art.Name;
                vm.Artist = a.Name;
                vm.Image = imageRepository.GetArtworkImage(art.Id);
                vm.Museum = art.Museum.Name;
                if (vm.Image != null)
                {
                    vm.ImageId = vm.Image.Id;
                }
                vm.Likes = likesRepository.GetLikes(a.Id);
                if (Autentification.GetLoggedUser(HttpContext) != null)
                {
                    Clients c = clientRepository.GetClientByUserId(Autentification.GetLoggedUser(HttpContext).Id);
                    vm.Liked = likesRepository.IsLiked(c.Id, a.Id);
                }
                else
                    vm.Liked = false;
                model.Artworks.Add(vm);
            }
            model.Biography = a.Biography;
            model.Born = a.Born;
            model.Country = a.Country.Name;
            model.Died = a.Died;
            model.Id = a.Id;
            model.Image = imageRepository.GetArtistImage(a.Id);
            if (model.Image != null)
            {
                model.ImageId = model.Image.Id;
            }
            model.Images = imageRepository.GetArtistImages(a.Id);
            model.Name = a.Name;
            IEnumerable<ArtistMovements> movements = stylesRepository.GetArtistMovementsByArtist(a.Id);
            foreach (ArtistMovements am in movements)
            {
                string style = am.Style.Name;
                model.Styles.Add(style);
            }
            return View("Details", model);
        }
    }
}