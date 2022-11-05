using BuyMyHouse.BLL.Interfaces;
using BuyMyHouse.DAL.Interfaces;
using BuyMyHouse.Model.DTOs;
using BuyMyHouse.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.BLL
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<FeedbackDTO> AddPersonAsync(PersonDTO personInfo)
        {
            return await _personRepository.AddPersonAsync(personInfo);
        }
    }
}
