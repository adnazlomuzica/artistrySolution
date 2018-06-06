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
        public IActionResult Index()
        {
            return View();
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

            imageRepository.InsertImage(i);
            imageRepository.Save();

            return RedirectToAction("AddArtwork", new { id = i.ArtworkId });
        }
    }
}