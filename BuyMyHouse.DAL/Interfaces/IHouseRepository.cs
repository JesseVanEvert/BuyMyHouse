using BuyMyHouse.Model.DTOs;
using BuyMyHouse.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.DAL.Interfaces
{
    public interface IHouseRepository
    {
        Task<House> AddHouse(HouseDTO houseInfo);
    }
}
