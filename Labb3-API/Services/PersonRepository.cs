using Labb3_API.Models;
using Labb3_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Services
{
    public class PersonRepository : IPersonRepository
    {
        private  AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<Person> GetById(int id)
        {
            return await _context.People.FindAsync(id);
        }

        public async Task<Person> Create(Person entity)
        {
            _context.People.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Person entity)
        {
            _context.People.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person != null)
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Person>> GetAllPersons()
        {
            return await GetAll();
        }

        public async Task<Person> GetPersonById(int personId)
        {
            return await GetById(personId);
        }
    }
}
