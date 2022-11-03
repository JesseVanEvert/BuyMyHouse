using BuyMyHouse.Model.DTOs;
using BuyMyHouse.Model.Entities;

namespace BuyMyHouse.DAL.Interfaces
{
    public interface IApplicationRepository
    {
        Task<string> ApplyToHouse(ApplicationDTO applicationInfo);
        HashSet<Application> GetApplicationsOfThisDay();
    }
}
