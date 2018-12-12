using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E18I4DABH4Gr4.Repositories;
using E18I4DABH4Gr4.Models;

namespace E18I4DABH4Gr4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProsumerController : ControllerBase
    {
        private IProsumerRepository repo;

        public ProsumerController()
        {
            repo = new ProsumerRepository();
        }

        // GET: api/People
        [HttpGet]
        public IEnumerable<Prosumer> GetProsumers()
        {
            return repo.GetAll();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProsumer([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Prosumer prosumer = repo.GetProsumer(id);

            if (prosumer == null)
            {
                return NotFound();
            }

            return Ok(prosumer);
        }

        // GETOVERPRODUCING: api/Prosumer/5
        [HttpGet("OverProducing")]
        public IActionResult GetOverProducingProsumer()
        {

            var prosumers = repo.GetAllOverProducingProsumers();

            if (prosumers.Any() == false)
                return NotFound();

            return Ok(prosumers);
        }

        // GETUNDERPRODUCING: api/Prosumer/5
        [HttpGet("UnderProducing")]
        public IActionResult GetUnderProducingProsumer()
        {

            var prosumers = repo.GetAllUnderProducingProsumers();

            if (prosumers.Any() == false)
                return NotFound();

            return Ok(prosumers);
        }
        // PUT: api/People/5
        [HttpPut("{name}")]
        public async Task<IActionResult> PutProsumer([FromRoute] string name, [FromBody] Prosumer prosumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (name != prosumer.Name)
            {
                return BadRequest();
            }

            await repo.Set(prosumer);

            return NoContent();
        }

        // POST: api/People
        [HttpPost]
        public async Task<IActionResult> PostProsumer([FromBody] Prosumer prosumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //prosumer.ProsumerId = "";

            await repo.Add(prosumer); // .ConfigureAwait(false);

            return CreatedAtAction("GetProsumer", new { id = prosumer.ProsumerId }, prosumer);
        }

        // DELETE: api/People/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteProsumer([FromRoute] string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Prosumer prosumer = repo.GetProsumer(name);

            if (prosumer == null)
            {
                return NotFound();
            }

            await repo.Remove(prosumer);

            return Ok(prosumer);
        }
    }
}