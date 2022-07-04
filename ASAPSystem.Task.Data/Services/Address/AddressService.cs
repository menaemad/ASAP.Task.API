using ASAPSystem.Assignment.Core.Helpers;
using ASAPSystem.Assignment.Core.Models;
using ASAPSystem.Assignment.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAPSystem.Assignment.Data.Services
{
    public class AddressService : IAddressService
    {
        #region Fields
        private readonly IRepository<Address> _repositoryAddress;

        #endregion

        #region Ctor
        public AddressService(IRepository<Address> repositoryAddress)
        {
            _repositoryAddress = repositoryAddress;
           
        }

        #endregion


        #region Methods
        public async Task DeleteAsync(Address address)=>
            await _repositoryAddress.DeleteAsync(address);
        

        public async Task DeleteAsync(int id)
        {
            var Address = await GetAddressByIdAsync(id);
            if (Address is not null)
                await DeleteAsync(Address);
        }

        public async Task<List<Address>> GetAllAddressesAsync(string name = null,
           string description = null)
            => (await GetAllAddressesAsync(name, description, 0, int.MaxValue, false)).ToList();

        public async Task<IPagedList<Address>> GetAllAddressesAsync(string name = null, string description = null, int pageIndex = 0, int pageSize = int.MaxValue, bool includeDeleted = true)
        {
            var addresss = await _repositoryAddress.GetAllPagedAsync(query =>
              {

                  if (!string.IsNullOrEmpty(name))
                      query = query.Where(x => x.Name.Contains(name));
                  if (!string.IsNullOrEmpty(description))
                      query = query.Where(x => x.Description.Contains(description));

                  return query.OrderBy(x => x.Id);
              }, pageIndex, pageSize, false, includeDeleted);
            return addresss;
        }

        public async Task<Address> GetAddressByIdAsync(int? id)
            => await _repositoryAddress.FindAsync(x => id.HasValue ? (x.Id == id.Value ) : false);


        public async Task InsertAsync(Address address)
        {
            await _repositoryAddress.AddAsync(address);
        }



        public async Task UpdateAsync(Address address)
        {
            await _repositoryAddress.UpdateAsync(address);
        }

        #endregion
    }
}
