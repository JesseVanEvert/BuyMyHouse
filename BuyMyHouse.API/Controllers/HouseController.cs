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
            return Ok(await _houseService.AddHouse(houseInfo));
        }

        [HttpGet("GetAllHouses")]
        public async Task<IActionResult> GetAllHouses()
        {
            return Ok(await _houseService.GetAllHousesAsync());
        }
    }
}