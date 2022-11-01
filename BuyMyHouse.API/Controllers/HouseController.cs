using BuyMyHouse.BLL.Interfaces;
using BuyMyHouse.Model.DTOs;
using BuyMyHouse.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuyMyHouse.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HouseController : ControllerBase
    {

        private readonly ILogger<HouseController> _logger;
        private readonly IHouseService _houseService;

        public HouseController(ILogger<HouseController> logger, IHouseService houseService)
        {
            _logger = logger;
            _houseService = houseService;
        }

        /*[HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

        }*/

        [HttpPost(Name = "AddHouse")]
        public async Task<House> AddHouse([FromBody] HouseDTO houseInfo)
        {
            return await _houseService.AddHouse(houseInfo);
        }
    }
}