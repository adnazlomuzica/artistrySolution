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
    public class MuseumController : Controller
    {
        private readonly IMuseumRepository museumRepository;
        private readonly IImageRepository imageRepository;

        public MuseumController(Context context)
        {
            this.museumRepository = new MuseumRepository(context);
            this.imageRepository = new ImageRepository(context);
        }

        [HttpGet]
        public IActionResult Index(int page=1)
        {
            List<Museums> list = museumRepository.GetMuseums();
            List<MuseumVM> model = new List<MuseumVM>();

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

            foreach (Museums x in list)
            {
                MuseumVM vm = new MuseumVM();
                vm.Id = x.Id;
                vm.Address = x.Address;
                vm.Name = x.Name;
                vm.Image = imageRepository.GetMuseumImage(x.Id);
                if (vm.Image != null)
                {
                    vm.ImageId = vm.Image.Id;
                }
                model.Add(vm);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Search(string search, int page = 1)
        {
            List<Museums> list = new List<Museums>();
            if (search != null)
            {
                list = museumRepository.Search(search);
            }
            else
            {
                list = museumRepository.GetMuseums();
            }
            List<MuseumVM> model = new List<MuseumVM>();

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

            foreach (Museums x in list)
            {
                MuseumVM vm = new MuseumVM();
                vm.Id = x.Id;
                vm.Address = x.Address;
                vm.Name = x.Name;
                vm.Image = imageRepository.GetMuseumImage(x.Id);
                if (vm.Image != null)
                {
                    vm.ImageId = vm.Image.Id;
                }
                model.Add(vm);
            }
            return View("Index",model);
        }

        [HttpGet]
        public IActionResult MapSearch(string search)
        {
            List<Museums> list = new List<Museums>();
            
          
                list = museumRepository.GetMuseums();
           
            List<MuseumVM> model = new List<MuseumVM>();
            foreach (Museums x in list)
            {
                MuseumVM vm = new MuseumVM();
                vm.Id = x.Id;
                vm.Address = x.Address;
                vm.Name = x.Name;
                vm.Latitude = x.Latitude;
                vm.Longitude = x.Longitude;
                vm.Image = imageRepository.GetMuseumImage(x.Id);
                if (vm.Image != null)
                {
                    vm.ImageId = vm.Image.Id;
                }
                model.Add(vm);
            }
            return View("Map", model);
        }
    }
}