using Labb3_API.Models;
using Labb3_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private IInterestRepository _interestRepository;

        public InterestController(IInterestRepository interestRepository)
        {
            _interestRepository = interestRepository;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interest>>> GetAllInterests()
        {
            var interests = await _interestRepository.GetAllInterests();
            return Ok(interests);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Interest>> GetInterestById(int id)
        {
            var interest = await _interestRepository.GetById(id);
            if (interest == null)
            {
                return NotFound();
            }
            return Ok(interest);
        }

        
        [HttpPost]
        public async Task<ActionResult<Interest>> CreateInterest([FromBody] Interest interest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdInterest = await _interestRepository.Create(interest);
            return CreatedAtAction(nameof(GetInterestById), new { id = createdInterest.InterestId }, createdInterest);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInterest(int id, [FromBody] Interest interest)
        {
            if (id != interest.InterestId)
            {
                return BadRequest("Not Found");
            }

            await _interestRepository.Update(interest);
            return Ok(interest);    
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterest(int id)
        {
            await _interestRepository.Delete(id);
            return Ok();
        }
    }
}
