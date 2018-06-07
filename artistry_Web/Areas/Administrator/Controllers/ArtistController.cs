using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Data.Models;
using artistry_Web.Areas.Administrator.ViewModels;
using artistry_Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace artistry_Web.Areas.Administrator.Controllers
{
    [Authorization(true, false, false)]
    [Area("Administrator")]
    [Route("Administrator/[controller]")]
    public class ArtistController : Controller
    {
        private readonly IArtistRepository artistRepository;
        private readonly IArtistMovementRepository artistmovementRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IStyleRepository styleRepository;
    

        public ArtistController(Context context)
        {
            this.artistRepository = new ArtistRepository(context);
            this.artistmovementRepository = new ArtistMovementRepository(context);
            this.countryRepository = new CountryRepository(context);
            this.styleRepository = new StyleRepository(context);
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
                    model.Add(vm);
                }
            
          
            return View("Index", model);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            ArtistVM model = new ArtistVM();

          
                model.Country = new SelectList(countryRepository.GetCountries(), "Id", "Name").ToList();
                model.Style = new SelectList(styleRepository.GetStyles(), "Id", "Name").ToList();
           
            return View("Add", model);
        }

        [HttpGet("GetArtist")]
        public IActionResult GetArtist(int id)
        {
            Artists a = artistRepository.GetArtistById(id);
            
            ArtistVM model = new ArtistVM()
            {
                Id=a.Id,
                Name=a.Name,
                Born=a.Born, 
                Died=a.Died, 
                CountryId=a.CountryId,
                Biography=a.Biography,
            };
            
                IEnumerable<ArtistMovements> am = artistmovementRepository.GetArtistMovementsByArtist(a.Id);

                model.StyleId = new List<int>();
                foreach (ArtistMovements x in am)
                {
                    model.StyleId.Add(x.StyleId);
                }

                model.Country = new SelectList(countryRepository.GetCountries(), "Id", "Name").ToList();
                model.Style = new SelectList(styleRepository.GetStyles(), "Id", "Name").ToList();
         
            return View("Edit", model);
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
          
            return View("Details", vm);
        }

        [HttpPost("Save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(ArtistVM artist)
        {
            if (!ModelState.IsValid)
            {
                artist.Country = new SelectList(countryRepository.GetCountries(), "Id", "Name").ToList();
                artist.Style = new SelectList(styleRepository.GetStyles(), "Id", "Name").ToList();

                return View("Add", artist);
            }
            Artists a = new Artists();

          
                a.Biography = artist.Biography;
                a.Born = artist.Born;
                a.CountryId = artist.CountryId;
                a.Died = artist.Died;
                a.Name = artist.Name;

                artistRepository.InsertArtist(a);
                artistRepository.Save();

                foreach (var x in artist.StyleId)
                {
                    ArtistMovements movements = new ArtistMovements();

                    movements.ArtistId = a.Id;
                    movements.StyleId = x;

                    artistmovementRepository.InsertArtistMovement(movements);
                }

                artistmovementRepository.Save();
          
            return RedirectToAction("Add", "Image", new { id = a.Id });
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ArtistVM artist)
        {
            if (!ModelState.IsValid)
            {
                artist.Country = new SelectList(countryRepository.GetCountries(), "Id", "Name").ToList();
                artist.Style = new SelectList(styleRepository.GetStyles(), "Id", "Name").ToList();

                return View("Edit", artist);
            }
          
                Artists a = new Artists();
                a.Id = artist.Id;
                a.Name = artist.Name;
                a.Biography = artist.Biography;
                a.Born = artist.Born;
                a.CountryId = artist.CountryId;
                a.Died = artist.Died;

                artistRepository.UpdateArtist(a);
                artistRepository.Save();

            IEnumerable<ArtistMovements> list = artistmovementRepository.GetArtistMovementsByArtist(artist.Id);

            foreach(var x in list)
            {
                artistmovementRepository.DeleteArtistMovement(x);
            }
            artistmovementRepository.Save();

            foreach (var x in artist.StyleId)
            {
                ArtistMovements movements = new ArtistMovements();

                movements.ArtistId = artist.Id;
                movements.StyleId = x;

                artistmovementRepository.InsertArtistMovement(movements);
            }

            artistmovementRepository.Save();
            
           
            return RedirectToAction("Index");
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
                model.Add(vm);
            }

            return View("Index", model);
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            artistRepository.DeleteArtist(id);
            artistRepository.Save();

            return RedirectToAction("Index");
        }
    }
}