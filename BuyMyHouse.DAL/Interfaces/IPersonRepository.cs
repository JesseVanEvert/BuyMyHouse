using BuyMyHouse.Model.DTOs;
using BuyMyHouse.Model.Entities;

namespace BuyMyHouse.DAL.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> AddPersonAsync(PersonDTO personInfo);
    }
}
