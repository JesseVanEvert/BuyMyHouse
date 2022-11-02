using BuyMyHouse.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.BLL.Interfaces
{
    public interface IApplicationService
    {
        Task<string> ApplyToHouse(ApplicationDTO applicationDTO);
    }
}
