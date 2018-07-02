using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspnetapp.Controllers
{
    [Produces("application/json")]
    [Route("api/Demo")]
    public class DemoController : Controller
    {
        public static List<string> localDB = new List<string>();

        // GET: api/Demo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return localDB.ToArray();
        }
        
        // POST: api/Demo
        [HttpPost]
        public int Post([FromBody]string value)
        {
            localDB.Add(value);
            return localDB.Count() - 1;
        }
        
        // PUT: api/Demo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            localDB[id] = value;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            localDB.Remove(localDB[id]);
        }
    }
}
