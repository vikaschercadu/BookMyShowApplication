using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookMyShow.Controllers
{
    public class SeatController : ApiController
    {
        // GET: api/Seat
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Seat/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Seat
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Seat/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Seat/5
        public void Delete(int id)
        {
        }
    }
}
