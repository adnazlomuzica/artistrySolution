﻿using System;
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
    public class ArtworkCollectionController : Controller
    {
        private readonly IArtworkCollectionRepository artworkCollectionRepository;
        private readonly ILikesRepository likesRepository;
        private readonly IImageRepository imageRepository;

        public ArtworkCollectionController(Context context)
        {
            this.artworkCollectionRepository = new ArtworkCollectionRepository(context);
            this.likesRepository = new LikesRepository(context);
            this.imageRepository = new ImageRepository(context);
        }

        [HttpGet("Index")]
        public PartialViewResult Index(int id)
        {
            List<ArtworkCollections> model=artworkCollectionRepository.GetArtworkCollections(id);

            List<ArtworkInfoVM> list = new List<ArtworkInfoVM>();

            foreach (ArtworkCollections x in model)
            {
                ArtworkInfoVM vm = new ArtworkInfoVM();
                vm.Id = x.Id;
                vm.Artist = x.Artwork.Artist.Name;
                vm.ArtistId = x.Artwork.ArtistId;
                vm.Likes = likesRepository.GetLikes(x.Id);
                vm.Name = x.Artwork.Name;
                vm.Image = imageRepository.GetArtworkImage(x.Id);
                vm.ImageId = vm.Image.Id;

                list.Add(vm);
            }

            return PartialView("Index", list);
        }
    }
}