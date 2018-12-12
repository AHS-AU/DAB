using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E18I4DABH32D1Gr4.Contexts;
using E18I4DABH32D1Gr4.Models;
using E18I4DABH32D1Gr4.Persistence.Repositories;
using E18I4DABH32D1Gr4.Core.IRepositories;

namespace E18I4DABH32D1Gr4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PersonContext _context;

        private IPersonRepository repo;
        public PeopleController(PersonContext context)
        {
            _context = context;

            repo = new PersonRepository();
            
        }

        // GET: api/People
        [HttpGet]
        public IEnumerable<Person> GetPeople()
        {
            return repo.GetAll();
        }

        // GET: api/People/5
        [HttpGet("{name}")]
        public async Task<IActionResult> GetPerson([FromRoute] string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Person person = repo.GetPerson(name);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson([FromRoute] string id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.PersonId)
            {
                return BadRequest();
            }

            await repo.Set(person);
        
            return NoContent();
        }

        // POST: api/People
        [HttpPost]
        public async Task<IActionResult> PostPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            person.PersonId = null;

            await repo.Add(person).ConfigureAwait(false);

            return CreatedAtAction("GetPerson", new { id = person.PersonId }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeletePerson([FromRoute] string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Person person = repo.GetPerson(name);

            if (person == null)
            {
                return NotFound();
            }

            await repo.Remove(person);

            return Ok(person);
        }

    }
}