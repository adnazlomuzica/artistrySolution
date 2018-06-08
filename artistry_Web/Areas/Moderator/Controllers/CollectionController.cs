using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Data.Models;
using artistry_Web.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace artistry_Web.Areas.Moderator.Controllers
{
    [Authorization(false, true, false)]
    [Area("Moderator")]
    [Route("Moderator/[controller]")]
    public class CollectionController : Controller
    {
        private readonly ICollectionRepository collectionRepository;
        private readonly IImageRepository imageRepository;
        private readonly IMuseumRepository museumRepository;

        public CollectionController(Context context)
        {
            this.collectionRepository = new CollectionRepository(context);
            this.imageRepository = new ImageRepository(context);
            this.museumRepository = new MuseumRepository(context);
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            int id = Autentification.GetLoggedUser(HttpContext).Id;
            Museums m = museumRepository.GetMuseumByAccId(id);

            List<Collections> model = collectionRepository.GetCollections(m.Id);

            foreach(Collections x in model)
            {
                if (x.Description.Length > 200)
                    x.Description = x.Description.Substring(0, 200);
            }

            return View("Index", model);
        }

        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            Collections model = collectionRepository.GetCollectionById(id);

            return View("Details", model);
        }

        [HttpGet("GetCollection")]
        public IActionResult GetCollection(int id)
        {
            Collections model = collectionRepository.GetCollectionById(id);

            return View("Edit", model);
        }

        [HttpGet("AddImage")]
        public IActionResult AddImage()
        {
            Images model = new Images();

            return View("AddImage", model);
        }

        [HttpGet("EditImage")]
        public IActionResult EditImage(int id)
        {
            Images model = imageRepository.GetImage(id);

            return View("EditImage", model);
        }

        [HttpGet("Add")]
        public IActionResult Add(int id)
        {
            int userId = Autentification.GetLoggedUser(HttpContext).Id;
            Museums m = museumRepository.GetMuseumByAccId(userId);

            Collections model = new Collections();
            model.MuseumId = m.Id;
            model.ImageId = id;

            return View("Add", model);
        }

        [HttpPost("SaveImage")]
        public IActionResult SaveImage(Images model, IFormFile imagefile)
        {
            if (!ModelState.IsValid)
            {
                return View("AddImage", model);
            }

            Images i = new Images();
            i.Caption = model.Caption;
            i.Primary = true;
            i.ImageThumb = ImageHelper.imageToByteArray(ImageHelper.ResizeImage(Image.FromStream(imagefile.OpenReadStream(), true, true), 150, 150));
            i.Image = ImageHelper.imageToByteArray(Image.FromStream(imagefile.OpenReadStream(), true, true));

            imageRepository.InsertImage(i);
            imageRepository.Save();

            return RedirectToAction("Add", new { id = i.Id });
        }

        [HttpPost("EditImg")]
        public IActionResult EditImg(Images model, IFormFile imagefile)
        {
            if (!ModelState.IsValid)
            {
                return View("AddImage", model);
            }

            Images i = new Images();
            i.Caption = model.Caption;
            i.Primary = true;
            i.ImageThumb = ImageHelper.imageToByteArray(ImageHelper.ResizeImage(Image.FromStream(imagefile.OpenReadStream(), true, true), 150, 150));
            i.Image = ImageHelper.imageToByteArray(Image.FromStream(imagefile.OpenReadStream(), true, true));

            imageRepository.UpdateImage(i);
            imageRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost("Save")]
        public IActionResult Save(Collections model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", model);
            }

            model.Active = true;

            collectionRepository.InsertCollection(model);
            collectionRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost("Edit")]
        public IActionResult Edit(Collections model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", model);
            }

            collectionRepository.UpdateCollection(model);
            collectionRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpGet("Deactivate")]
        public IActionResult Deactivate(int id)
        {
            Collections c = collectionRepository.GetCollectionById(id);
            c.Active = false;
            collectionRepository.UpdateCollection(c);
            collectionRepository.Save();

            return RedirectToAction("Details", new { id = c.Id });
        }

        [HttpGet("Activate")]
        public IActionResult Activate(int id)
        {
            Collections c = collectionRepository.GetCollectionById(id);
            c.Active = true;
            collectionRepository.UpdateCollection(c);
            collectionRepository.Save();

            return RedirectToAction("Details", new { id = c.Id });
        }
    }
}