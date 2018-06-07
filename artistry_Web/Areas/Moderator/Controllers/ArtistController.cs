using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Data.Models;
using artistry_Web.Areas.Moderator.ViewModels;
using artistry_Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace artistry_Web.Areas.Moderator.Controllers
{
    [Authorization(false, true, false)]
    [Area("Moderator")]
    [Route("Moderator/[controller]")]
    public class ArtistController : Controller
    {
        private readonly IArtistRepository artistRepository;
        private readonly IArtistMovementRepository artistmovementRepository;
        private readonly IStyleRepository styleRepository;
        private readonly IImageRepository imageRepository;
        private readonly IArtworkRepository artworkRepository;

        public ArtistController(Context context)
        {
            this.artistRepository = new ArtistRepository(context);
            this.artistmovementRepository = new ArtistMovementRepository(context);
            this.artworkRepository = new ArtworkRepository(context);
            this.styleRepository = new StyleRepository(context);
            this.imageRepository = new ImageRepository(context);
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            IEnumerable<Artists> artists = artistRepository.GetArtists();
            List<ArtistInfoVM> model = new List<ArtistInfoVM>();
            foreach (Artists a in artists)
            {
                ArtistInfoVM vm = new ArtistInfoVM();

                vm.Id = a.Id;
                vm.Name = a.Name;
                vm.Born = a.Born;
                vm.Died = a.Died;
                vm.Country = a.Country.Name;
                vm.Styles = artistmovementRepository.GetArtistMovementsByArtist(a.Id);
                vm.Artworks = artworkRepository.GetArtworksByArtist(a.Id);
                vm.Image = imageRepository.GetArtistImage(a.Id);
                vm.ImageId = vm.Image.Id;
                model.Add(vm);
            }

            return View("Index", model);
        }

        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            ArtistInfoVM vm = new ArtistInfoVM();

            Artists a = artistRepository.GetArtistById(id);

            vm.Id = a.Id;
            vm.Name = a.Name;
            vm.Born = a.Born;
            vm.Died = a.Died;
            vm.Country = a.Country.Name;
            vm.Styles = artistmovementRepository.GetArtistMovementsByArtist(a.Id);
            vm.Artworks = artworkRepository.GetArtworksByArtist(a.Id);
            vm.Image = imageRepository.GetArtistImage(a.Id);
            vm.ImageId = vm.Image.Id;

            return View("Details", vm);
        }

        [HttpGet("Search")]
        public IActionResult Search(string search)
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
            List<ArtistInfoVM> model = new List<ArtistInfoVM>();

            foreach (Artists a in artist)
            {
                ArtistInfoVM vm = new ArtistInfoVM();

                vm.Id = a.Id;
                vm.Name = a.Name;
                vm.Born = a.Born;
                vm.Died = a.Died;
                vm.Country = a.Country.Name;
                vm.Styles = artistmovementRepository.GetArtistMovementsByArtist(a.Id);
                vm.Artworks = artworkRepository.GetArtworksByArtist(a.Id);
                vm.Image = imageRepository.GetArtistImage(a.Id);
                vm.ImageId = vm.Image.Id;
                model.Add(vm);
            }

            return View("Index", model);
        }
    }
}