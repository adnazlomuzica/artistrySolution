using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Data.Models;
using artistry_Web.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using artistry_Web.Areas.Administrator.ViewModels;

namespace artistry_Web.Areas.Moderator.Controllers
{
    [Authorization(false, true, false)]
    [Area("Moderator")]
    [Route("Moderator/[controller]")]
    public class ImageController : Controller
    {
        private readonly IImageRepository imageRepository;

        public ImageController(Context context)
        {
            this.imageRepository = new ImageRepository(context);
        }
        [HttpGet("Index")]
        public PartialViewResult Index(int id)
        {
            IEnumerable<Images> images = imageRepository.GetArtistImages(id);
            ImageVM model = new ImageVM();

            model.Images = images.Select(y => new ImageIndexVM
            {
                Caption = y.Caption,
                Id = y.Id
            }).ToList();
            model.ArtistId = id;

            return PartialView("PartialIndex", model);
        }

        [HttpGet("RenderImage")]
        public async Task<ActionResult> RenderImage(int id)
        {
            Images image = await imageRepository.GetImageById(id);

            byte[] photoBack = image.Image;

            return File(photoBack, "image/png");
        }

        [HttpGet("RenderThumb")]
        public async Task<ActionResult> RenderThumb(int id)
        {
            Images image = await imageRepository.GetImageById(id);

            byte[] photoBack = image.ImageThumb;

            return File(photoBack, "thumb/png");
        }

        [HttpGet("Add")]
        public IActionResult Add(int id)
        {
            Images model = new Images();
            model.MuseumId = id;
            
            return View(model);
        }

        [HttpGet("AddArtwork")]
        public IActionResult AddArtwork(int id)
        {
            Images model = new Images();
            model.ArtworkId = id;

            return View(model);
        }

        [HttpGet("AddNews")]
        public IActionResult Addnews(int id)
        {
            Images model = new Images();
            model.NewsId = id;

            return View(model);
        }

        [HttpPost("Save")]
        public IActionResult Save(Images image, IFormFile imagefile)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", image);
            }

            Images i = new Images();
            i.Caption = image.Caption;
            i.MuseumId = image.MuseumId;
            i.Primary = image.Primary;
            i.ImageThumb = ImageHelper.imageToByteArray(ImageHelper.ResizeImage(Image.FromStream(imagefile.OpenReadStream(), true, true), 150, 150));
            i.Image = ImageHelper.imageToByteArray(Image.FromStream(imagefile.OpenReadStream(), true, true));

            IEnumerable<Images> images = imageRepository.GetMuseumImages(Convert.ToInt32(i.MuseumId));

            if (images.Where(x => x.Primary == true).Count() == 0)
            {
                i.Primary = true;
            }
            if(images.Where(x=>x.Primary).Count()>0 && i.Primary)
            {
                Images img = images.Where(x => x.Primary).SingleOrDefault();
                img.Primary = false;
                imageRepository.UpdateImage(img);
            }

            imageRepository.InsertImage(i);
            imageRepository.Save();

            return RedirectToAction("Add", new { id = i.MuseumId });
        }

        [HttpPost("SaveArtwork")]
        public IActionResult SaveArtwork(Images image, IFormFile imagefile)
        {
            if (!ModelState.IsValid)
            {
                return View("AddArtwork", image);
            }

            Images i = new Images();
            i.Caption = image.Caption;
            i.ArtworkId = image.ArtworkId;
            i.Primary = image.Primary;
            i.ImageThumb = ImageHelper.imageToByteArray(ImageHelper.ResizeImage(Image.FromStream(imagefile.OpenReadStream(), true, true), 150, 150));
            i.Image = ImageHelper.imageToByteArray(Image.FromStream(imagefile.OpenReadStream(), true, true));

            IEnumerable<Images> images = imageRepository.GetArtworkImages(Convert.ToInt32(i.ArtworkId));

            if (images.Where(x => x.Primary == true).Count() == 0)
            {
                i.Primary = true;
            }
            if (images.Where(x => x.Primary).Count() > 0 && i.Primary)
            {
                Images img = images.Where(x => x.Primary).SingleOrDefault();
                img.Primary = false;
                imageRepository.UpdateImage(img);
            }

            imageRepository.InsertImage(i);
            imageRepository.Save();

            return RedirectToAction("AddArtwork", new { id = i.ArtworkId });
        }

        [HttpPost("SaveNews")]
        public IActionResult SaveNews(Images image, IFormFile imagefile)
        {
            if (!ModelState.IsValid)
            {
                return View("AddNews", image);
            }

            Images i = new Images();
            i.Caption = image.Caption;
            i.NewsId = image.NewsId;
            i.Primary = image.Primary;
            i.ImageThumb = ImageHelper.imageToByteArray(ImageHelper.ResizeImage(Image.FromStream(imagefile.OpenReadStream(), true, true), 150, 150));
            i.Image = ImageHelper.imageToByteArray(Image.FromStream(imagefile.OpenReadStream(), true, true));

            IEnumerable<Images> images = imageRepository.GetNewsImages(Convert.ToInt32(i.NewsId));

            if (images.Where(x => x.Primary == true).Count() == 0)
            {
                i.Primary = true;
            }
            if (images.Where(x => x.Primary).Count() > 0 && i.Primary)
            {
                Images img = images.Where(x => x.Primary).SingleOrDefault();
                img.Primary = false;
                imageRepository.UpdateImage(img);
            }

            imageRepository.InsertImage(i);
            imageRepository.Save();

            return RedirectToAction("AddNews", new { id = i.NewsId });
        }
    }
}