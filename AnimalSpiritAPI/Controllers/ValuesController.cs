using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AnimalSpiritAPI.Controllers
{
    [Route("api/[controller]")]
    public class AnimalSpiritController : Controller
    {
        // GET api/AnimalSpirit
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/AnimalSpirit/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/AnimalSpirit
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/AnimalSpirit/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/AnimalSpirit/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
