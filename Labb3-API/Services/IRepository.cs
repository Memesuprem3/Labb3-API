using Labb3_API.Models;

namespace Labb3_API.Services
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }

    public interface IPersonRepository : IRepository<Person>
    {
        Task<IEnumerable<Person>> GetAllPersons();
        Task<Person> GetPersonById(int personId);
    }

    public interface IInterestRepository : IRepository<Interest>
    {
        Task<IEnumerable<Interest>> GetAllInterests();
        Task<IEnumerable<Interest>> GetInterestsByPersonId(int personId);
    }

    public interface ILinkRepository : IRepository<Link>
    {
        Task<IEnumerable<Link>> GetLinksByPersonInterestId(int personInterestId);
    }

    public interface IPersonInterestRepository : IRepository<PersonInterest>
    {
        Task<PersonInterest> LinkPersonToInterest(int personId, int interestId);
        Task AddLinkToPersonInterest(int personInterestId, string url);
    }
}
