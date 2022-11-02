using BuyMyHouse.Model.DTOs;
using BuyMyHouse.Model.Entities;

namespace BuyMyHouse.BLL.Interfaces
{
    public interface IPersonService
    {
        Task<Person> AddPersonAsync(PersonDTO personInfo);
    }
}
