using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace artistry_Web.Controllers
{
    [Route("[controller]/[action]")]
    public class ImageController : Controller
    {
        private readonly IImageRepository imageRepository;

        public ImageController(Context context)
        {
            this.imageRepository = new ImageRepository(context);
        }

        [HttpGet]
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
    }
}