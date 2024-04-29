using Labb3_API.Models;
using Labb3_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly ILinkRepository _linkRepository;

        public LinkController(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Link>>> GetAllLinks()
        {
            var links = await _linkRepository.GetAll();
            return Ok(links);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Link>> GetLinkById(int id)
        {
            var link = await _linkRepository.GetById(id);
            if (link == null)
            {
                return NotFound();
            }
            return Ok(link);
        }

        
        [HttpPost]
        public async Task<ActionResult<Link>> CreateLink([FromBody] Link link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdLink = await _linkRepository.Create(link);
            return CreatedAtAction(nameof(GetLinkById), new { id = createdLink.LinkId }, createdLink);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLink(int id, [FromBody] Link link)
        {
            if (id != link.LinkId)
            {
                return BadRequest();
            }

            await _linkRepository.Update(link);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLink(int id)
        {
            await _linkRepository.Delete(id);
            return NoContent();
        }
    }
}
