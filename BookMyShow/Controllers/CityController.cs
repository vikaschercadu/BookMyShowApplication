using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Services.CityService;
using Models.CoreModels;
namespace BookMyShow.Controllers
{
    public class CityController : ApiController
    {
        private readonly ICityService CityService;
        public CityController(ICityService cityService)
        {
            CityService=cityService;

        }
        // GET: api/City
        public IEnumerable<CityDTO> Get()
        {
            return CityService.GetCities();
        }

        // GET: api/City/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/City
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/City/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/City/5
        public void Delete(int id)
        {
        }
    }
}
