using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BandBookerData;
using BandBookerData.Models;


namespace BandBooker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentsController : ControllerBase
    {
        // GET: api/Instruments
        [HttpGet]
        public IEnumerable<Instrument> Get()
        {
            return DataManager.Instruments;
        }


        // GET: api/Instruments/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }


        // POST: api/Instruments
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


        // PUT: api/Instruments/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}