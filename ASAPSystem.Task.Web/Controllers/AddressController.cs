using ASAPSystem.Assignment.Core.Models;
using ASAPSystem.Assignment.Data.Services;
using ASAPSystem.Assignment.Web.Models;
using ASAPSystem.Assignment.Web.Models.Address;
using AutoMapper;
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
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public AddressController(IAddressService addressService, IMapper mapper, IPersonService personService)
        {
            _addressService = addressService;
            _mapper = mapper;
            _personService = personService;
        }
        #endregion

        #region Methods
        [HttpGet("get")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var address = await _addressService.GetAddressByIdAsync(id);
            if (address is not null)
                return Ok(new ResponseModel() { Data = address });

            return BadRequest(new ResponseModel()
            {
                Data = null,
                StatusCode = (int)HttpStatusCode.BadRequest,
                IsSuccessed = false,
                Message = "Can not find address"
            });

        }
        [HttpPost("getAll")]
        public async Task<IActionResult> GetAllAsync(SerarchAddressModel model)
        {
            var addresses = await _addressService.GetAllAddressesAsync(model.Name, model.Description, model.PageIndex, model.PageSize);
            return Ok(new ResponseModel() { Data = addresses });
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(AddressModel model)
        {
            if (ModelState.IsValid)
            {
                if ((await _personService.GetPersonByIdAsync(model.PersonId)) != null)
                {
                    var address = _mapper.Map<Address>(model);
                    await _addressService.InsertAsync(address);
                    return Ok(new ResponseModel { Data = address, Message = "Address created successfully" });
                }
                return BadRequest(new ResponseModel { Data = null, Message = "Person can not found", IsSuccessed = false, StatusCode = (int)HttpStatusCode.BadRequest });

            }
            return BadRequest(new ResponseModel { Data = null, Message = "Can not create address", IsSuccessed = false, StatusCode = (int)HttpStatusCode.BadRequest });
        }


        [HttpPut("edit")]
        public async Task<IActionResult> EditAsync(AddressModel model)
        {
            if (ModelState.IsValid)
            {
                var address = await _addressService.GetAddressByIdAsync(model.Id);
                if (address is not null)
                {
                    if ((await _personService.GetPersonByIdAsync(model.PersonId)) != null)
                    {
                        _mapper.Map(model, address);
                        await _addressService.UpdateAsync(address);
                        return Ok(new ResponseModel { Data = address, Message = "Address updated successfully" });
                    }
                    return BadRequest(new ResponseModel { Data = null, Message = "Person can not found", IsSuccessed = false, StatusCode = (int)HttpStatusCode.BadRequest });

                }
                return BadRequest(new ResponseModel { Data = null, Message = "Address can not found", IsSuccessed = false, StatusCode = (int)HttpStatusCode.BadRequest });

            }
            return BadRequest(new ResponseModel { Data = null, Message = "Can not update address", IsSuccessed = false, StatusCode = (int)HttpStatusCode.BadRequest });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var address = await _addressService.GetAddressByIdAsync(Id);
            if (address is not null)
            {
                await _addressService.DeleteAsync(address);
                return Ok(new ResponseModel { Data = address, Message = "Address deleted successfully" });
            }
            return BadRequest(new ResponseModel { Data = null, Message = "Can not found address", IsSuccessed = false, StatusCode = (int)HttpStatusCode.BadRequest });
        }


        #endregion
    }
}
