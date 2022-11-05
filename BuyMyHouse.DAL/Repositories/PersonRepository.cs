using BuyMyHouse.DAL.Interfaces;
using BuyMyHouse.Model.DTOs;
using BuyMyHouse.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuyMyHouse.DAL.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Context _context;

        public PersonRepository(Context context)
        {
            _context = context;
        }

        public async Task<FeedbackDTO> AddPersonAsync(PersonDTO personInfo)
        {
            Person person = new()
            {
                Email = personInfo.Email,
                PersonID = Guid.NewGuid(),
                Firstname = personInfo.Firstname,
                Prefix = personInfo.Prefix,
                Lastname = personInfo.Lastname,
                YearlyIncomeInEuros = personInfo.YearlyIncomeInEuros,
            };

            await _context.Person.AddAsync(person);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbex)
            {
                return new FeedbackDTO()
                {
                    Success = false,
                    Message = "Person could not be added",
                    Exception = dbex.Message
                };
            }

            return new FeedbackDTO()
            {
                Success = true,
                Message = $"Person with id: {person.PersonID} has been added"
            };
        }
    }
}
