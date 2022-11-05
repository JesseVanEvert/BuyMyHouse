using BuyMyHouse.Model.DTOs;
using BuyMyHouse.Model.Entities;

namespace BuyMyHouse.DAL.Interfaces
{
    public interface IApplicationRepository
    {
        Task<FeedbackDTO> ApplyToHouse(ApplicationDTO applicationInfo);
        HashSet<Application> GetApplicationsOfThisDay();
        HashSet<Application> GetApplicationsOfYesterday();
    }
}
