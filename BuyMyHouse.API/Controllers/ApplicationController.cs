using BuyMyHouse.BLL.Interfaces;
using BuyMyHouse.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BuyMyHouse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost("ApplyToHouse")]
        public async Task<IActionResult> ApplyToHouse([FromBody] ApplicationDTO applicationInfo)
        {
            return Ok(await _applicationService.ApplyToHouse(applicationInfo));
        }
    }
}
