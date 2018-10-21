using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artistry_API.Models;
using artistry_Data.Context;
using artistry_Data.DAL;
using artistry_Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace artistry_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IArtworkRepository artworkRepository;

        public ValuesController(Context context)
        {
            this.artworkRepository = new ArtworkRepository(context);
        }
        // GET api/values
        [HttpGet]
        [Route("Get")]
        public IActionResult Get(int id)
        {
            //int c = Int32.Parse(id);
            Artworks a = artworkRepository.ScanTickets(id);

            if (a != null)
            {
                ArtworkVM model = new ArtworkVM();
                model.Id = a.Id;
                model.Artist = a.Artist.Name;
                model.Description = a.CatalogueEntry;
                model.Material = a.Material.Name;
                model.Name = a.Name;
                model.Style = a.Style.Name;
                model.Type = a.ArtworkType.Name;
                model.Year = a.Date;
                return Ok(model);
            }

            return Ok();
        }

       

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
