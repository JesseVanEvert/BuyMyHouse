using BuyMyHouse.BLL.Interfaces;
using BuyMyHouse.Model.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.BLL
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _email;

        public EmailService()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            _email = configuration["EmailAddress"];

            _smtpClient = new SmtpClient(configuration["EmailClient"])
            {
                Port = 587,
                Credentials = new NetworkCredential(configuration["EmailAddress"], configuration["EmailPassword"]),
                EnableSsl = true,
            };
        }

        public async Task SendEmailToApplicants(Application application)
        {
            foreach (Person applicant in application.Applicants)
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_email),
                    Subject = $"Your application with id: {application.ApplicationID}",
                    Body = $"<p>You can find your application and the mortgage offer at: https://localhost:7026/mortgage/getmortgagepdfdocument?mortgageID={applicant.ApplicationID}</p>",
                    IsBodyHtml = true,
                };

                mailMessage.To.Add("jesse.vanevert@outlook.com");

                _smtpClient.Send(mailMessage);
            }
        }
    }
}
