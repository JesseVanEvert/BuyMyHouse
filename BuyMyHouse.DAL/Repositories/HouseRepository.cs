﻿using BuyMyHouse.DAL.Interfaces;
using BuyMyHouse.Model.DTOs;
using BuyMyHouse.Model.Entities;
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

        public async Task<House> AddHouse(HouseDTO houseInfo)
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
            await _context.SaveChangesAsync();

            return house;
        }
    }
}
