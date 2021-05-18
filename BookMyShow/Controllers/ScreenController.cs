using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookMyShow.Controllers
{
    public class ScreenController : ApiController
    {
        // GET: api/Screen
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Screen/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Screen
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Screen/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Screen/5
        public void Delete(int id)
        {
        }
    }
}
