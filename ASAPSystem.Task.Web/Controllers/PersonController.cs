using ASAPSystem.Assignment.Data.Services;
using ASAPSystem.Assignment.Web.Models;
using ASAPSystem.Assignment.Web.Models.Person;
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
        #endregion

        #region Ctor
        public PersonController(IPersonService personService)
        {
            _personService = personService;
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
        #endregion
    }
}
