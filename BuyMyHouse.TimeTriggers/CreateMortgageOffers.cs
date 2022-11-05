using System;
using System.Threading.Tasks;
using BuyMyHouse.BLL.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace BuyMyHouse.TimeTriggers
{
    public class CreateMortgageOffers
    {
        private IMortgageService _mortgageService;

        public CreateMortgageOffers(IMortgageService mortgageService)
        {
            _mortgageService = mortgageService;
        }

        [FunctionName("CreateMortgageOffers")]
        public async Task Run([TimerTrigger("* * 23 * * *")] TimerInfo myTimer, ILogger log)
        {
            await _mortgageService.StoreMortgageOffersOfThisDayInCache();
        }
    }
}
