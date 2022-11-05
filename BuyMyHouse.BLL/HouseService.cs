using BuyMyHouse.BLL.Interfaces;
using BuyMyHouse.DAL;
using BuyMyHouse.DAL.Interfaces;
using BuyMyHouse.Model.DTOs;
using BuyMyHouse.Model.Entities;

namespace BuyMyHouse.BLL
{
    public class HouseService : IHouseService
    {
        private readonly IHouseRepository _houseRepository;

        public HouseService(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository; 
        }

        public async Task<FeedbackDTO> AddHouse(HouseDTO houseInfo)
        {
            return await _houseRepository.AddHouseAsync(houseInfo);  
        }

        public async Task<IEnumerable<House>> GetAllHousesAsync()
        {
            return await _houseRepository.GetAllHousesAsync();
        }
    }
}