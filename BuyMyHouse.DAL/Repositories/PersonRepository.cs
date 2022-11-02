using BuyMyHouse.DAL.Interfaces;
using BuyMyHouse.Model.DTOs;
using BuyMyHouse.Model.Entities;


namespace BuyMyHouse.DAL.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Context _context;

        public PersonRepository(Context context)
        {
            _context = context;
        }
    
        public async Task<Person> AddPersonAsync(PersonDTO personInfo)
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
            await _context.SaveChangesAsync();

            return person;
        }
    }
}
