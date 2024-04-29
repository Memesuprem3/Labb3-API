using Labb3_API.Data;
using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Services
{
    public class InterestRepository : IInterestRepository
    {
        private AppDbContext _context;

        public InterestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _context.Interests.ToListAsync();
        }

        public async Task<Interest> GetById(int id)
        {
            return await _context.Interests.FindAsync(id);
        }

        public async Task<Interest> Create(Interest entity)
        {
            _context.Interests.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Interest entity)
        {
            _context.Interests.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var interest = await _context.Interests.FindAsync(id);
            if (interest != null)
            {
                _context.Interests.Remove(interest);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Interest>> GetAllInterests()
        {
            return await GetAll();
        }

        public async Task<IEnumerable<Interest>> GetInterestsByPersonId(int personId)
        {
            return await _context.PersonInterests
                .Where(pi => pi.PersonId == personId)
                .Select(pi => pi.Interest)
                .ToListAsync();
        }
    }
}
