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
    public class NewsController : Controller
    {
        private readonly INewsRepository newsRepository;
        private readonly IImageRepository imageRepository;
        private readonly IMuseumRepository museumRepository;

        public NewsController(Context context)
        {
            this.newsRepository = new NewsRepository(context);
            this.imageRepository = new ImageRepository(context);
            this.museumRepository = new MuseumRepository(context);
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            int id = Autentification.GetLoggedUser(HttpContext).Id;
            Museums m = museumRepository.GetMuseumByAccId(id);

            List<News> news = newsRepository.GetNews(m.Id);
            List<NewsVM> model = new List<NewsVM>();

            foreach(News x in news)
            {
                NewsVM vm = new NewsVM();

                vm.Id = x.Id;
                vm.Date = x.Date;
                vm.MuseumId = x.MuseumId;
                vm.Subtitle = x.SubTitle;

                if (x.Text.Length > 200)
                {
                    vm.Text = x.Text.Substring(0, 200);
                }
                else
                {
                    vm.Text = x.Text;
                }
                vm.Title = x.Title;
                vm.Images = imageRepository.GetNewsImage(x.Id);
                if (vm.Images != null)
                {
                    vm.ImageId = vm.Images.Id;
                }
                vm.Img = null;

                model.Add(vm);
            }
            return View("Index", model);
        }

        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            News n = newsRepository.GetNewsById(id);
            NewsVM model = new NewsVM();

            model.Id = n.Id;
            model.Date = n.Date;
            model.MuseumId = n.MuseumId;
            model.Subtitle = n.SubTitle;
            model.Text = n.Text;
            model.Title = n.Title;
            model.Img = imageRepository.GetNewsImages(n.Id);

            return View("Details", model);
        }

        [HttpGet("GetNews")]
        public IActionResult GetNews(int id)
        {
            News model = newsRepository.GetNewsById(id);

            return View("Edit", model);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            int id = Autentification.GetLoggedUser(HttpContext).Id;
            Museums m = museumRepository.GetMuseumByAccId(id);

            News model = new News();
            model.MuseumId = m.Id;

            return View("Add", model);
        }

        [HttpPost("Save")]
        public IActionResult Save(News model)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", model);
            }

            model.Date = DateTime.Now;

            newsRepository.InsertNews(model);
            newsRepository.Save();

            return RedirectToAction("AddNews", "Image", new { id = model.Id });
        }

        [HttpPost("Edit")]
        public IActionResult Edit(News model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            model.Date = DateTime.Now;

            newsRepository.UpdateNews(model);
            newsRepository.Save();

            return RedirectToAction("Details", new { id = model.Id });
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            newsRepository.DeleteNews(id);
            newsRepository.Save();

            return RedirectToAction("Index");
        }

    }
}