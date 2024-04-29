using Labb3_API.Data;
using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Services
{
    public class PersonInterestRepository : IPersonInterestRepository
    {
        private AppDbContext _context;

        public PersonInterestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PersonInterest>> GetAll()
        {
            return await _context.PersonInterests
                .Include(pi => pi.Person)
                .Include(pi => pi.Interest)
                .ToListAsync();
        }

        public async Task<PersonInterest> GetById(int id)
        {
            return await _context.PersonInterests
                .Include(pi => pi.Person)
                .Include(pi => pi.Interest)
                .FirstOrDefaultAsync(pi => pi.PersonInterestId == id);
        }

        public async Task<PersonInterest> Create(PersonInterest entity)
        {
            _context.PersonInterests.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(PersonInterest entity)
        {
            _context.PersonInterests.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var personInterest = await _context.PersonInterests.FindAsync(id);
            if (personInterest != null)
            {
                _context.PersonInterests.Remove(personInterest);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<PersonInterest> LinkPersonToInterest(int personId, int interestId)
        {
            var personInterest = new PersonInterest { PersonId = personId, InterestId = interestId };
            _context.PersonInterests.Add(personInterest);
            await _context.SaveChangesAsync();
            return personInterest;
        }

        public async Task AddLinkToPersonInterest(int personInterestId, string url)
        {
            var link = new Link { Url = url, PersonInterestId = personInterestId };
            _context.Links.Add(link);
            await _context.SaveChangesAsync();
        }
    }
}
