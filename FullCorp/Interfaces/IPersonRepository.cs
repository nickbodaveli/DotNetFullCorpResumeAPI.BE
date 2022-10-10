using FullCorp.Models.Dto.Experience;
using FullCorp.Models.Dto.Person;
using FullCorp.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace FullCorp.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<PersonDto>> GetAllPersons();
        Task<PersonDto> GetPerson(int id);
        Task<int> GetPersonByUserId(int userId);
        Task<bool> AddPerson(CreatePersonDto request);
        Task<bool> UpdatePerson(int id, CreatePersonDto request);
        Task<bool> DeletePerson(int id);
    }
}
