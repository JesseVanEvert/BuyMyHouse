using BuyMyHouse.Model.DTOs;
using BuyMyHouse.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.BLL.Interfaces
{
    public interface IHouseService
    {
        Task<House> AddHouse(HouseDTO houseInfo);
    }
}
