using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E18I4DABH32D1Gr4.Contexts;
using E18I4DABH32D1Gr4.Models;
using E18I4DABH32D1Gr4.Core;

namespace E18I4DABH32D1Gr4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleRepoController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public PeopleRepoController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/PeopleRepo
        [HttpGet]
        public IEnumerable<Person> GetPeople()
        {
            return _context.People.GetAll();
        }

        // GET: api/PeopleRepo/5
        [HttpGet("{id}")]
        public IActionResult GetPerson([FromRoute] int id)
        {
            //var person = await _context.People.FindAsync(id);
            var person = _context.People.Get(id);

            return Ok(person);
        }

        // PUT: api/PeopleRepo/5
        [HttpPut("{id}")]
        public IActionResult PutPerson([FromRoute] int id, [FromBody] Person person)
        {
            if (PersonExists(id))
            {
                _context.People.Put(person);
                _context.Complete();

            }
            else
            {
                return NotFound();
            }
            return Ok(person);
        }

        // POST: api/PeopleRepo
        [HttpPost]
        public void PostPerson([FromBody] Person person)
        {
            _context.People.Add(person);
            _context.Complete();
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public IActionResult DeletePerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = _context.People.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            _context.Complete();

            return Ok(person);
        }

        private bool PersonExists(int id)
        {
            var Person = _context.People.Find(e => e.PersonId == id);
            if(Person != null)
            {
                return true;
            }
            return false;
            //return _context.People.Find(e => e.PersonId == id);
        }
    }
}