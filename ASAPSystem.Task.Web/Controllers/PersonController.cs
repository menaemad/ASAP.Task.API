using ASAPSystem.Assignment.Core.Models;
using ASAPSystem.Assignment.Data.Services;
using ASAPSystem.Assignment.Web.Models;
using ASAPSystem.Assignment.Web.Models.Person;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ASAPSystem.Assignment.Web.Controllers
{
    [Route("api/person")]
    [ApiController]

    public class PersonController : ControllerBase
    {
        #region Fields
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        [HttpGet("get")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);
            if (person is not null)
                return Ok(new ResponseModel() { Data = person });

            return BadRequest(new ResponseModel()
            {
                Data = null,
                StatusCode = (int)HttpStatusCode.BadRequest,
                IsSuccessed = false,
                Message = "Can not find person"
            });

        }
        [HttpPost("getAll")]
        public async Task<IActionResult> GetAllAsync(SerarchPersonModel model)
        {
            var persons = await _personService.GetAllPersonsAsync(model.FullName, model.Email, model.PageIndex, model.PageSize);
            return Ok(new ResponseModel() { Data = persons });
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(PersonModel model)
        {
            if (ModelState.IsValid)
            {
                var person = _mapper.Map<Person>(model);
                await _personService.InsertAsync(person);
                return Ok(new ResponseModel { Data = person, Message = "Person created successfully" });
            }
            return BadRequest(new ResponseModel { Data = null, Message = "Person can not create successfully", IsSuccessed = false, StatusCode = (int)HttpStatusCode.BadRequest });
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditAsync(PersonModel model)
        {
            if (ModelState.IsValid)
            {
                var person = await _personService.GetPersonByIdAsync(model.Id);
                if (person is not null)
                {
                    _mapper.Map(model, person);
                    await _personService.UpdateAsync(person);
                    return Ok(new ResponseModel { Data = person, Message = "Person updated successfully" });
                }
                return BadRequest(new ResponseModel { Data = null, Message = "Person can not found", IsSuccessed = false, StatusCode = (int)HttpStatusCode.BadRequest });
            }
            return BadRequest(new ResponseModel { Data = null, Message = "Can not update person", IsSuccessed = false, StatusCode = (int)HttpStatusCode.BadRequest });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var person = await _personService.GetPersonByIdAsync(Id);
            if (person is not null)
            {
                await _personService.DeleteAsync(person);
                return Ok(new ResponseModel { Data = person, Message = "Person deleted successfully" });
            }
            return BadRequest(new ResponseModel { Data = null, Message = "Can not found person", IsSuccessed = false, StatusCode = (int)HttpStatusCode.BadRequest });
        }



        #endregion
    }
}
