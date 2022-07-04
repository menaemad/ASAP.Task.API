using ASAPSystem.Assignment.Data.Services;
using ASAPSystem.Assignment.Web.Models;
using ASAPSystem.Assignment.Web.Models.Address;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ASAPSystem.Assignment.Web.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/address")]
    public class AddressController : ControllerBase
    {
        #region Fields
        private readonly IAddressService _addressService;
        #endregion
        
        #region Ctor
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        } 
        #endregion

        #region Methods
        [HttpGet("get")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var address= await _addressService.GetAddressByIdAsync(id);
            if (address is not null)
                return Ok(new ResponseModel(){Data =address});

            return BadRequest(new ResponseModel() 
            {   Data = null, 
                StatusCode= (int)HttpStatusCode.BadRequest,
                IsSuccessed=false,
                Message="Can not find address"
            });

        }
        [HttpPost("getAll")]
        public async Task<IActionResult> GetAllAsync(SerarchAddressModel model)
        {
            var addresses = await _addressService.GetAllAddressesAsync(model.Name,model.Description,model.PageIndex,model.PageSize);
                return Ok(new ResponseModel() { Data = addresses });
        }
        #endregion
    }
}
