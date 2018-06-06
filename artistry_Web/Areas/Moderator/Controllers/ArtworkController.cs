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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace artistry_Web.Areas.Moderator.Controllers
{
    [Authorization(false, true, false)]
    [Area("Moderator")]
    [Route("Moderator/[controller]")]
    public class ArtworkController : Controller
    {
        private readonly IArtworkRepository artworkRepository;
        private readonly IArtworkTypeRepository artworkTypeRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IStyleRepository styleRepository;
        private readonly IMaterialRepository materialRepository;
        private readonly IArtistRepository artistRepository;
        private readonly IMuseumRepository museumRepository;
        private readonly ILikesRepository likesRepository;
        private readonly IImageRepository imageRepository;

        public ArtworkController(Context context)
        {
            this.artworkRepository = new ArtworkRepository(context);
            this.artworkTypeRepository = new ArtworkTypeRepository(context);
            this.countryRepository = new CountryRepository(context);
            this.styleRepository = new StyleRepository(context);
            this.materialRepository = new MaterialRepository(context);
            this.artistRepository = new ArtistRepository(context);
            this.museumRepository = new MuseumRepository(context);
            this.likesRepository = new LikesRepository(context);
            this.imageRepository = new ImageRepository(context);
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            int id = Autentification.GetLoggedUser(HttpContext).Id;
            Museums m = museumRepository.GetMuseumByAccId(id);

            List<Artworks> model = artworkRepository.GetArtworksByMuseum(m.Id);

            List<ArtworkInfoVM> list = new List<ArtworkInfoVM>();

            foreach(Artworks x in model)
            {
                ArtworkInfoVM vm = new ArtworkInfoVM();
                vm.Id = x.Id;
                vm.Artist = x.Artist.Name;
                vm.ArtistId = x.ArtistId;
                vm.Likes = likesRepository.GetLikes(x.Id);
                vm.Name = x.Name;
                vm.Image = imageRepository.GetArtworkImage(x.Id);
                vm.ImageId = vm.Image.Id;

                list.Add(vm);
            }

            return View("Index", list);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            int id = Autentification.GetLoggedUser(HttpContext).Id;
            Museums m = museumRepository.GetMuseumByAccId(id);

            ArtworkVM model = new ArtworkVM();

            model.Artist = new SelectList(artistRepository.GetArtists(), "Id", "Name");
            model.ArtworkType = new SelectList(artworkTypeRepository.GetArtworkTypes(), "Id", "Name");
            model.Country = new SelectList(countryRepository.GetCountries(), "Id", "Name");
            model.Material = new SelectList(materialRepository.GetMaterials(), "Id", "Name");
            model.Style = new SelectList(styleRepository.GetStyles(), "Id", "Name");

            model.MuseumId = m.Id;

            return View("Add", model);
        }

        [HttpPost("Save")]
        [ValidateAntiForgeryToken]
        public IActionResult Save(ArtworkVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Artist = new SelectList(artistRepository.GetArtists(), "Id", "Name");
                model.ArtworkType = new SelectList(artworkTypeRepository.GetArtworkTypes(), "Id", "Name");
                model.Country = new SelectList(countryRepository.GetCountries(), "Id", "Name");
                model.Material = new SelectList(materialRepository.GetMaterials(), "Id", "Name");
                model.Style = new SelectList(styleRepository.GetStyles(), "Id", "Name");
                return View("Add", model);
            }

            Artworks a = new Artworks();
            a.AccessionNumber = model.AccessionNumber;
            a.Active = true;
            a.ArtistId = model.ArtistId;
            a.ArtworkTypeId = model.ArtworkTypeId;
            a.CatalogueEntry = model.CatalogueEntry;
            a.CountryId = model.CountryId;
            a.Date = model.Date;
            a.MaterialId = model.MaterialId;
            a.MuseumId = model.MuseumId;
            a.Name = model.Name;
            a.Provenance = model.Provenance;
            a.StyleId = model.StyleId;

            artworkRepository.InsertArtwork(a);
            artworkRepository.Save();

            return RedirectToAction("AddArtwork", "Image", new { id=a.Id});
        }
    }
}