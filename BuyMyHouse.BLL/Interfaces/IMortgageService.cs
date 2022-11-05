using BuyMyHouse.Model;
using BuyMyHouse.Model.Entities;

namespace BuyMyHouse.BLL.Interfaces
{
    public interface IMortgageService
    {
        Task StoreMortgageOffersOfThisDayInCache();
        Task<byte[]> GeneratePDFFromMortgage(Mortgage mortgage);
        Task<byte[]> GetTemporaryPDFFromCache(Guid mortgageID);
        HashSet<Application> GetApplicationsOfThisDay();
        HashSet<Application> GetApplicationsOfYesterday();
    }
}
