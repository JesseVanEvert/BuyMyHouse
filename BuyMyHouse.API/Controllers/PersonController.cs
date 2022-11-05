using BuyMyHouse.BLL.Interfaces;
using BuyMyHouse.Model.DTOs;
using BuyMyHouse.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuyMyHouse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("AddPerson")]
        public async Task<IActionResult> AddPerson([FromBody] PersonDTO personInfo)
        {
            FeedbackDTO addPersonFeedback = await _personService.AddPersonAsync(personInfo);

            if (!addPersonFeedback.Success)
                return StatusCode(500, addPersonFeedback);

            return Ok(addPersonFeedback);
        } 
    }
}
