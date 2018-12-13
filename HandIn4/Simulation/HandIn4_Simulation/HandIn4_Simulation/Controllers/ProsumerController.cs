using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using HandIn4_Simulation.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace HandIn4_Simulation.Controllers
{
    public class ProsumerController
    {
        static string mApiUrl = "http://localhost:50955/api/Prosumer";

        static HttpClient mHttpClient = new HttpClient();

        //// GET: api/Prosumer
        public async Task<List<Prosumer>> GetAllProsumersAsync()
        {
            string responseBody = await mHttpClient.GetStringAsync(new Uri(mApiUrl));
            return JsonConvert.DeserializeObject<List<Prosumer>>(responseBody);
        }

        //// GET: api/Prosumer/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetProsumer([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Prosumer prosumer = repo.GetProsumer(id);

        //    if (prosumer == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(prosumer);
        //}

        //// GETOVERPRODUCING: api/Prosumer/5
        //[HttpGet("OverProducing")]
        //public IActionResult GetOverProducingProsumer()
        //{

        //    var prosumers = repo.GetAllOverProducingProsumers();

        //    if (prosumers.Any() == false)
        //        return NotFound();

        //    return Ok(prosumers);
        //}

        //// GETUNDERPRODUCING: api/Prosumer/5
        //[HttpGet("UnderProducing")]
        //public IActionResult GetUnderProducingProsumer()
        //{

        //    var prosumers = repo.GetAllUnderProducingProsumers();

        //    if (prosumers.Any() == false)
        //        return NotFound();

        //    return Ok(prosumers);
        //}
        //// PUT: api/People/5
        //[HttpPut("{name}")]
        //public async Task<IActionResult> PutProsumer([FromRoute] string name, [FromBody] Prosumer prosumer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (name != prosumer.Name)
        //    {
        //        return BadRequest();
        //    }

        //    await repo.Set(prosumer);

        //    return NoContent();
        //}

        //// POST: api/People
        //[HttpPost]
        //public async Task<IActionResult> PostProsumer([FromBody] Prosumer prosumer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    //prosumer.ProsumerId = "";

        //    await repo.Add(prosumer); // .ConfigureAwait(false);

        //    return CreatedAtAction("GetProsumer", new { id = prosumer.ProsumerId }, prosumer);
        //}

        //// DELETE: api/People/5
        //[HttpDelete("{name}")]
        //public async Task<IActionResult> DeleteProsumer([FromRoute] string name)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Prosumer prosumer = repo.GetProsumer(name);

        //    if (prosumer == null)
        //    {
        //        return NotFound();
        //    }

        //    await repo.Remove(prosumer);

        //    return Ok(prosumer);
        //}
    }
}