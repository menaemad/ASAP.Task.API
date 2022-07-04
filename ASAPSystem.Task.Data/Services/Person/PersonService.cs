using ASAPSystem.Assignment.Core.Helpers;
using ASAPSystem.Assignment.Core.Models;
using ASAPSystem.Assignment.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAPSystem.Assignment.Data.Services
{
    public class PersonService : IPersonService
    {
        #region Fields
        private readonly IRepository<Person> _repositoryPerson;

        #endregion

        #region Ctor
        public PersonService(IRepository<Person> repositoryPerson)
        {
            _repositoryPerson = repositoryPerson;

        }

        #endregion


        #region Methods
        public async Task DeleteAsync(Person person) =>
            await _repositoryPerson.DeleteAsync(person);


        public async Task DeleteAsync(int id)
        {
            var Person = await GetPersonByIdAsync(id);
            if (Person is not null)
                await DeleteAsync(Person);
        }

        public async Task<List<Person>> GetAllPersonsAsync(string fullName = null,
           string email = null)
            => (await GetAllPersonsAsync(fullName, email, 0, int.MaxValue, false)).ToList();

        public async Task<IPagedList<Person>> GetAllPersonsAsync(string fullName = null, string email = null, int pageIndex = 0, int pageSize = int.MaxValue, bool includeDeleted = true)
        {
            var persons = await _repositoryPerson.GetAllPagedAsync(query =>
              {

                  if (!string.IsNullOrEmpty(fullName))
                      query = query.Where(x => x.FullName.Contains(fullName));
                  if (!string.IsNullOrEmpty(email))
                      query = query.Where(x => x.Email.Contains(email));

                  return query.OrderBy(x => x.Id);
              }, pageIndex, pageSize, false, includeDeleted);
            return persons;
        }

        public async Task<Person> GetPersonByIdAsync(int? id)
            => await _repositoryPerson.FindAsync(x => id.HasValue ? (x.Id == id.Value) : false);


        public async Task InsertAsync(Person person)
        {
            await _repositoryPerson.AddAsync(person);
        }



        public async Task UpdateAsync(Person person)
        {
            await _repositoryPerson.UpdateAsync(person);
        }
        #endregion
    }
}
