using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AVC.Controllers
{
    public class APItestController : ApiController
    {
        // GET: api/APItest
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/APItest/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/APItest
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/APItest/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/APItest/5
        public void Delete(int id)
        {
        }
    }
}
