using Labb3_API.Data;
using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Services
{
    public class LinkRepository : ILinkRepository
    {
        private AppDbContext _context;

        public LinkRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Link>> GetAll()
        {
            return await _context.Links.ToListAsync();
        }

        public async Task<Link> GetById(int id)
        {
            return await _context.Links.FindAsync(id);
        }

        public async Task<Link> Create(Link entity)
        {
            _context.Links.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Link entity)
        {
            _context.Links.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var link = await _context.Links.FindAsync(id);
            if (link != null)
            {
                _context.Links.Remove(link);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Link>> GetLinksByPersonInterestId(int personInterestId)
        {
            return await _context.Links
                .Where(l => l.PersonInterestId == personInterestId)
                .ToListAsync();
        }
    }
}
