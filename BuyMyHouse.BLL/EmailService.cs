using BuyMyHouse.BLL.Interfaces;
using BuyMyHouse.Model.Entities;
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

        public EmailService()
        {
            _smtpClient = new SmtpClient()
            {
                Port = 587,
                Credentials = new NetworkCredential("jessesmail.jve@gmail.com", "xrcutgsfjmrjhdch"),
                EnableSsl = true,
            };
        }

        public async Task SendEmailToApplicants(Application application)
        {
            foreach (Person applicant in application.Applicants)
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("jessesmail.jve@gmail.com"),
                    Subject = $"Your application with id: {application.ApplicationID}",
                    Body = $"<p>{applicant.Email} You can find your application and the mortgage offer at: https://localhost:7026/mortgage/getmortgagepdfdocument?mortgageID={applicant.ApplicationID}</p>",
                    IsBodyHtml = true,
                };
                mailMessage.To.Add("jesse.vanevert@outlook.com");

                _smtpClient.Send(mailMessage);
            }
        }
    }
}
