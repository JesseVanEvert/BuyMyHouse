using BuyMyHouse.BLL.Interfaces;
using BuyMyHouse.Model.Entities;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.TimeTriggers
{
    public class SendEmailWithMortgageOffer
    {
        private readonly IMortgageService _mortgageService;
        private readonly IEmailService _emailService;

        public SendEmailWithMortgageOffer(IMortgageService mortgageService, IEmailService emailService)
        {
            _mortgageService = mortgageService;
            _emailService = emailService;
        }

        [FunctionName("SendEmailToApplicants")]
        public void Run([TimerTrigger("* * 6 * * *")] TimerInfo myTimer, ILogger log)
        {
            HashSet<Application> applications = _mortgageService.GetApplicationsOfYesterday();

            foreach (Application application in applications)
            {
              _emailService.SendEmailToApplicants(application);
            }
        }
    }
}
