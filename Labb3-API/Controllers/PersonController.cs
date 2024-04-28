using Labb3_API.Data;
using Labb3_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            return await _context.People.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }


        [HttpGet("{id}/Interests")]
        public async Task<ActionResult<IEnumerable
<PersonInterest>>> GetPersonInterests(int id)
        {
            var person = await _context.People
            .Include(p => p.PersonInterests)
            .ThenInclude(pi => pi.Interest)
            .FirstOrDefaultAsync(p => p.PersonId == id);


            if (person == null)
            {
                return NotFound();
            }

            return person.PersonInterests.ToList();
        }


        [HttpGet("{id}/Link")]
        public async Task<ActionResult<IEnumerable<Link>>> GetPersonLinks(int id)
        {
            var person = await _context.People
                .Include(p => p.PersonInterests)
                .ThenInclude(pi => pi.Links)
                .FirstOrDefaultAsync(p => p.PersonId == id);

            if (person == null)
            {
                return NotFound();
            }

            var links = person.PersonInterests.SelectMany(pi => pi.Links);
            return links.ToList();
        }


        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.PersonId }, person);
        }

        [HttpPost("{id}/interests")]
        public async Task<ActionResult<Interest>> PostInterest(Interest interest)
        {
            _context.Interests.Add(interest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("AddIntrest", new { id = interest.PersonInterests }, interest);
        }

        [HttpPost("{id}/Link")]
        public async Task<ActionResult> AddLinkToPerson(int id, Link link)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            var personInterest = await _context.PersonInterests.FirstOrDefaultAsync(pi => pi.PersonId == id && pi.InterestId == link.PersonInterestId);

            if (personInterest == null)
            {
                return BadRequest("Interest not found.");
            }

            _context.Links.Add(link);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonLinks", new { id = id }, link);
        }


        [HttpPost("{id}/Interests/{interestId}")]
        public async Task<ActionResult> AddInterestToPerson(int id, int interestId)
        {
            var person = await _context.People.FindAsync(id);
            var interest = await _context.Interests.FindAsync(interestId);

            if (person == null || interest == null)
            {
                return NotFound();
            }

            var personInterest = new PersonInterest { PersonId = id, InterestId = interestId };
            _context.PersonInterests.Add(personInterest);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        
    }
}