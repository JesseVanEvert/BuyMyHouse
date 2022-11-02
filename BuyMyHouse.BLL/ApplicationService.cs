using BuyMyHouse.BLL.Interfaces;
using BuyMyHouse.DAL.Interfaces;
using BuyMyHouse.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.BLL
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<string> ApplyToHouse(ApplicationDTO applicationDTO)
        {
            return await _applicationRepository.ApplyToHouse(applicationDTO);
        }
    }
}
