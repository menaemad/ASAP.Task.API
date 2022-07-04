using System.Collections.Generic;
using System.Threading.Tasks;
using ASAPSystem.Assignment.Core.Helpers;
using ASAPSystem.Assignment.Core.Models;


namespace ASAPSystem.Assignment.Data.Services
{
   public interface IAddressService
    {
        Task<Address> GetAddressByIdAsync(int? id);
        Task<List<Address>> GetAllAddressesAsync(string name = null, string description = null);
        Task<IPagedList<Address>> GetAllAddressesAsync(string name = null,
            string description = null, int pageIndex = 0, int pageSize = int.MaxValue, bool includeDeleted=true);

        Task InsertAsync(Address address);
        Task UpdateAsync(Address address);
        Task DeleteAsync(Address address);
        Task DeleteAsync(int id);


    }
}
