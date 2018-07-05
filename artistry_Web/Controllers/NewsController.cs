using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Data.Models;
using artistry_Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace artistry_Web.Controllers
{
    [Route("[controller]/[action]")]
    public class NewsController : Controller
    {
        private readonly INewsRepository newsRepository;
        private readonly IImageRepository imageRepository;

        public NewsController(Context context)
        {
            this.newsRepository = new NewsRepository(context);
            this.imageRepository = new ImageRepository(context);
        }

        [HttpGet]
        public IActionResult Index(int page=1)
        {
            List<News> news = newsRepository.GetAllNews();
            List<NewsVM> model = new List<NewsVM>();

            const int PageSize = 10;

            var count = model.Count();

            if (page == 1)
            {
                news = news.Skip(0).Take(PageSize).ToList();
            }
            else
            {
                news = news.Skip((page - 1) * PageSize).Take(PageSize).ToList();
            }

            if (count <= 10)
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

            foreach (News x in news)
            {
                NewsVM vm = new NewsVM();

                vm.Id = x.Id;
                vm.Date = x.Date;
                vm.Image = imageRepository.GetNewsImage(x.Id);
                if (vm.Image != null) {
                    vm.ImageId = vm.Image.Id;
                }
                vm.Museum = x.Museum.Name;
                vm.Subtitle = x.SubTitle;
                vm.Text = x.Text;
                vm.Title = x.Title;

                model.Add(vm);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Search(string search,int page = 1)
        {
            List<News> news = new List<News>();
            if (search != null)
            {
                 news= newsRepository.Search(search);
            }
            else
            {
                news = newsRepository.GetAllNews();
            }
            List<NewsVM> model = new List<NewsVM>();

            const int PageSize = 10;

            var count = model.Count();

            if (page == 1)
            {
                news = news.Skip(0).Take(PageSize).ToList();
            }
            else
            {
                news = news.Skip((page - 1) * PageSize).Take(PageSize).ToList();
            }

            if (count <= 10)
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

            foreach (News x in news)
            {
                NewsVM vm = new NewsVM();

                vm.Id = x.Id;
                vm.Date = x.Date;
                vm.Image = imageRepository.GetNewsImage(x.Id);
                if (vm.Image != null)
                {
                    vm.ImageId = vm.Image.Id;
                }
                vm.Museum = x.Museum.Name;
                vm.Subtitle = x.SubTitle;
                vm.Text = x.Text;
                vm.Title = x.Title;

                model.Add(vm);
            }

            return View("Index",model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            News n = newsRepository.GetNewsById(id);

            NewsVM model = new NewsVM();
            model.Date = n.Date;
            model.Id = n.Id;
            model.Image = imageRepository.GetNewsImage(n.Id);
            if (model.Image != null)
            {
                model.ImageId = model.Image.Id;
            }
            model.Images = imageRepository.GetNewsImages(n.Id);
            model.Museum = n.Museum.Name;
            model.Subtitle = n.SubTitle;
            model.Text = n.Text;
            model.Title = n.Title;

            return View("Details", model);
        }
    }
}