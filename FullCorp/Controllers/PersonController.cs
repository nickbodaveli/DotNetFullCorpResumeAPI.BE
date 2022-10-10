using FullCorp.Interfaces;
using FullCorp.Models.Dto.Experience;
using FullCorp.Models.Dto.Person;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCorp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet("GetAllPersons")]
        public async Task<IActionResult> GetAllPersons()
        {
            var person = await _personRepository.GetAllPersons();
            if (person != null) return Ok(person);
            else
                return NotFound();
        }

        [HttpGet("GetPerson/{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var person = await _personRepository.GetPerson(id);
            if (person != null) return Ok(person);
            else
                return NotFound();
        }

        [HttpGet("GetPersonByUserId/{id}")]
        public async Task<IActionResult> GetPersonByUserId(int id)
        {
            var person = await _personRepository.GetPersonByUserId(id);
            if (person != null) return Ok(person);
            else
                return NotFound();
        }

        [HttpPost("AddPerson")]
        public async Task<IActionResult> AddPerson([FromBody] CreatePersonDto request)
        {
            var person = await _personRepository.AddPerson(request);
            if (person != null) return Ok(person);
            else
                return NotFound();
        }

        [HttpPut("UpdatePerson/{id}")]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] CreatePersonDto request)
        {
            var person = await _personRepository.UpdatePerson(id, request);
            if (person != null) return Ok(person);
            else
                return NotFound();
        }

        [HttpDelete("DeletePerson/{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _personRepository.DeletePerson(id);
            if (person != null) return Ok(person);
            else
                return NotFound();
        }
    }
}
