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
    public class ArtworkController : Controller
    {
        private readonly IArtistRepository artistRepository;
        private readonly IImageRepository imageRepository;
        private readonly IArtworkRepository artworkRepository;
        private readonly IArtistMovementRepository stylesRepository;
        private readonly IArtworkTypeRepository artworktypeRepository;
        private readonly IMaterialRepository materialRepository;
        private readonly ILikesRepository likesRepository;
        private readonly IClientRepository clientRepository;


        public ArtworkController(Context context)
        {
            this.artistRepository = new ArtistRepository(context);
            this.imageRepository = new ImageRepository(context);
            this.artworkRepository = new ArtworkRepository(context);
            this.stylesRepository = new ArtistMovementRepository(context);
            this.artworktypeRepository = new ArtworkTypeRepository(context);
            this.materialRepository = new MaterialRepository(context);
            this.likesRepository = new LikesRepository(context);
            this.clientRepository = new ClientRepository(context);
        }

        [HttpGet]
        public IActionResult Index(int page=1)
        {
            List<Artworks> list = artworkRepository.GetArtworks();
            List<ArtworkVM> model = new List<ArtworkVM>();
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
            foreach (Artworks x in list)
            {
                ArtworkVM vm = new ArtworkVM();
                vm.Id = x.Id;
                vm.Artist = x.Artist.Name;
                vm.ArtworkType = x.ArtworkType.Name;
                vm.ArtworkTypeId = x.ArtworkTypeId;
                vm.CatalogueEntry = x.CatalogueEntry;
                vm.Country = x.Country.Name;
                vm.Image = imageRepository.GetArtworkImage(x.Id);
                if (vm.Image != null)
                {
                    vm.ImageId = vm.Image.Id;
                }
                vm.Likes = likesRepository.GetLikes(x.Id);
                vm.Material = x.Material.Name;
                vm.Museum = x.Museum.Name;
                vm.MuseumId = x.MuseumId;
                vm.Name = x.Name;
                vm.Provenance = x.Provenance;
                vm.Style = x.Style.Name;
                if (Autentification.GetLoggedUser(HttpContext) != null)
                {
                    Clients c = clientRepository.GetClientByUserId(Autentification.GetLoggedUser(HttpContext).Id);
                    vm.Liked = likesRepository.IsLiked(c.Id, x.Id);
                }
                else
                    vm.Liked = false;
                model.Add(vm);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Search(string search, int page=1)
        {
            IEnumerable<Artworks> list;
            if (search != null)
            {
                list = artworkRepository.Search(search, null);
            }

            else
            {
                list = artworkRepository.GetArtworks();
            }

            List<ArtworkVM> model = new List<ArtworkVM>();
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
            foreach (Artworks x in list)
            {
                ArtworkVM vm = new ArtworkVM();
                vm.Id = x.Id;
                vm.Artist = x.Artist.Name;
                vm.ArtworkType = x.ArtworkType.Name;
                vm.ArtworkTypeId = x.ArtworkTypeId;
                vm.CatalogueEntry = x.CatalogueEntry;
                vm.Country = x.Country.Name;
                vm.Image = imageRepository.GetArtworkImage(x.Id);
                if (vm.Image != null)
                {
                    vm.ImageId = vm.Image.Id;
                }
                vm.Likes = likesRepository.GetLikes(x.Id);
                vm.Material = x.Material.Name;
                vm.Museum = x.Museum.Name;
                vm.MuseumId = x.MuseumId;
                vm.Name = x.Name;
                vm.Provenance = x.Provenance;
                vm.Style = x.Style.Name;
                if (Autentification.GetLoggedUser(HttpContext) != null)
                {
                    Clients c = clientRepository.GetClientByUserId(Autentification.GetLoggedUser(HttpContext).Id);
                    vm.Liked = likesRepository.IsLiked(c.Id, x.Id);
                }
                else
                    vm.Liked = false;
                model.Add(vm);
            }


            return View("Index", model);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            Artworks x = artworkRepository.GetArtworkById(id);
            ArtworkVM vm = new ArtworkVM();
            vm.Id = x.Id;
            vm.Artist = x.Artist.Name;
            vm.ArtworkType = x.ArtworkType.Name;
            vm.ArtworkTypeId = x.ArtworkTypeId;
            vm.CatalogueEntry = x.CatalogueEntry;
            vm.Country = x.Country.Name;
            vm.Image = imageRepository.GetArtworkImage(x.Id);
            if (vm.Image != null)
            {
                vm.ImageId = vm.Image.Id;
            }
            vm.Likes = likesRepository.GetLikes(x.Id);
            vm.Material = x.Material.Name;
            vm.Museum = x.Museum.Name;
            vm.MuseumId = x.MuseumId;
            vm.Name = x.Name;
            vm.Provenance = x.Provenance;
            vm.Style = x.Style.Name;
            vm.Images = imageRepository.GetArtworkImages(x.Id);
            if (Autentification.GetLoggedUser(HttpContext) != null)
            {
                Clients c = clientRepository.GetClientByUserId(Autentification.GetLoggedUser(HttpContext).Id);
                vm.Liked = likesRepository.IsLiked(c.Id, x.Id);
            }
            else
                vm.Liked = false;

            return View(vm);
        }

        [HttpGet]
        public void Like(int id)
        {
            if (Autentification.GetLoggedUser(HttpContext) != null)
            {
                Clients c = clientRepository.GetClientByUserId(Autentification.GetLoggedUser(HttpContext).Id);
                Likes like = new Likes();
                like.ArtworkId = id;
                like.ClientId = c.Id;

                likesRepository.InsertLike(like);
                likesRepository.Save();

            }

        }

        [HttpGet]
        public void Unlike(int id)
        {
            if (Autentification.GetLoggedUser(HttpContext) != null)
            {
                Clients c = clientRepository.GetClientByUserId(Autentification.GetLoggedUser(HttpContext).Id);
                likesRepository.DeleteLike(c.Id, id);
                likesRepository.Save();
            }
        }
    }
}