using BuyMyHouse.DAL.Interfaces;
using BuyMyHouse.Model.DTOs;
using BuyMyHouse.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.DAL.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly Context _context;
        public HouseRepository(Context context)
        {
            _context = context;
        }

        public async Task<FeedbackDTO> AddHouseAsync(HouseDTO houseInfo)
        {
            House house = new()
            {
                HouseID = Guid.NewGuid(),
                Number = houseInfo.Number,
                Street = houseInfo.Street,
                Postcode = houseInfo.Postcode,
                Location = houseInfo.Location,
                AskingPrice = houseInfo.AskingPrice
            };

            await _context.House.AddAsync(house);

            try
            {
               await _context.SaveChangesAsync();
            }
            catch(DbUpdateException dbex)
            {
                return new FeedbackDTO()
                {
                    Success = false,
                    Message = "The house could not be added",
                    Exception = dbex.Message
                };
            }

            return new FeedbackDTO()
            {
                Success = true,
                Message = $"The house with id:{house.HouseID} has been added"
            };
        }

        public async Task<IEnumerable<House>> GetAllHousesAsync()
        {
            return await _context.House.ToListAsync();
        }
    }
}
