using BuyMyHouse.Model.DTOs;

namespace BuyMyHouse.DAL.Interfaces
{
    public interface IApplicationRepository
    {
        Task<string> ApplyToHouse(ApplicationDTO applicationInfo);
    }
}
