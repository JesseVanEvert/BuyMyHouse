using BuyMyHouse.DAL.Interfaces;
using BuyMyHouse.Model.DTOs;
using BuyMyHouse.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuyMyHouse.DAL.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly Context _context;

        public ApplicationRepository(Context context)
        {
            _context = context;
        }

        public async Task<FeedbackDTO> ApplyToHouse(ApplicationDTO applicationInfo)
        {
            Application application = new() { 
                ApplicationID = Guid.NewGuid(),
                Applicants = new HashSet<Person>(),
                AppliedAt = DateTime.Now,
            };

            Person applicantOne =  await _context.Person.FindAsync(applicationInfo.ApplicantOneID);
            Person applicantTwo = await _context.Person.FindAsync(applicationInfo.ApplicantTwoID);
            House house = await _context.House.FindAsync(applicationInfo.HouseID);


            if(applicantTwo != null)
                 application.Applicants.Add(applicantTwo);

            if (applicantOne == null)
                return new FeedbackDTO() { Success = false, Message = "The primary applicant has not been found" };

            if (house == null)
                return new FeedbackDTO() { Success = false, Message = "The house has not been found" };

            application.Applicants.Add(applicantOne);

            house.Applications = new HashSet<Application>();
            house.Applications.Add(application);

            await _context.Application.AddAsync(application);

            try
            {
               await _context.SaveChangesAsync();
            } 
            catch (DbUpdateException dbex)
            {
                return new FeedbackDTO()
                {
                    Success = false,
                    Message = "The application failed",
                    Exception = dbex.Message
                };
            }
            

            return new FeedbackDTO() { Success = true, Message = $"Successfully applied to house. Application id: {application.ApplicationID}"};
        }

        public HashSet<Application> GetApplicationsOfThisDay()
        {
            return _context.Application
                .Where(a => a.AppliedAt.Date == DateTime.Now.Date)
                .Include(p => p.Applicants)
                .Include(h => h.House)
                .ToHashSet();
        }

        public HashSet<Application> GetApplicationsOfYesterday()
        {
            return _context.Application
                .Where(a => a.AppliedAt.Date == DateTime.Now.AddDays(-1).Date)
                .Include(p => p.Applicants)
                .Include(h => h.House)
                .ToHashSet();
        }
    }
}
