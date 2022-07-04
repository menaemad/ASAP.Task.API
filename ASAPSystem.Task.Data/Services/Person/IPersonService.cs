using System.Collections.Generic;
using System.Threading.Tasks;
using ASAPSystem.Assignment.Core.Helpers;
using ASAPSystem.Assignment.Core.Models;


namespace ASAPSystem.Assignment.Data.Services
{
   public interface IPersonService
    {
        Task<Person> GetPersonByIdAsync(int? id);
        Task<List<Person>> GetAllPersonsAsync(string fullName = null, string email = null);
        Task<IPagedList<Person>> GetAllPersonsAsync(string fullName = null,
            string email = null, int pageIndex = 0, int pageSize = int.MaxValue, bool includeDeleted=true);

        Task InsertAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(Person person);
        Task DeleteAsync(int id);


    }
}
