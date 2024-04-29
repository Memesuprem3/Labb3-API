using Labb3_API.Models;
using Labb3_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonInterestController : ControllerBase
    {
        private readonly IPersonInterestRepository _personInterestRepository;

        public PersonInterestController(IPersonInterestRepository personInterestRepository)
        {
            _personInterestRepository = personInterestRepository;
        }

       
        [HttpPost]
        public async Task<ActionResult<PersonInterest>> LinkPersonToInterest([FromBody] PersonInterest personInterest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdPersonInterest = await _personInterestRepository.LinkPersonToInterest(personInterest.PersonId, personInterest.InterestId);
            return CreatedAtAction("GetPersonInterest", new { id = createdPersonInterest.PersonInterestId }, createdPersonInterest);
        }

        
        [HttpPost("link")]
        public async Task<ActionResult> AddLinkToPersonInterest([FromBody] Link link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _personInterestRepository.AddLinkToPersonInterest(link.PersonInterestId, link.Url);
            return Ok();
        }
    }
}
