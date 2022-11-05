using BuyMyHouse.BLL.Interfaces;
using BuyMyHouse.Model.DTOs;
using BuyMyHouse.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuyMyHouse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HouseController : ControllerBase
    {

        private readonly ILogger<HouseController> _logger;
        private readonly IHouseService _houseService;

        public HouseController(ILogger<HouseController> logger, IHouseService houseService)
        {
            _logger = logger;
            _houseService = houseService;
        }

        [HttpPost("AddHouse")]
        public async Task<IActionResult> AddHouse([FromBody] HouseDTO houseInfo)
        {
            FeedbackDTO addHouseFeedback = await _houseService.AddHouse(houseInfo);

            if (!addHouseFeedback.Success)
                return StatusCode(500, addHouseFeedback);

            return Ok(addHouseFeedback);
        }

        [HttpGet("GetAllHouses")]
        public async Task<IActionResult> GetAllHouses()
        {
            IEnumerable<House> houses = await _houseService.GetAllHousesAsync();

            if(houses == null || houses.Any() == false)
                return NotFound("No houses have been found");

            return Ok(houses);
        }
    }
}