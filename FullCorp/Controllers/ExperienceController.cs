using FullCorp.Interfaces;
using FullCorp.Models.Dto.Experience;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCorp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceRepository _experienceRepository;

        public ExperienceController(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        [HttpGet("GetExperiences")]
        public async Task<IActionResult> GetExperiences()
        {
            var person = await _experienceRepository.GetExperiences();
            if (person != null) return Ok(person);
            else
                return NotFound();
        }

        [HttpGet("GetExperience/{id}")]
        public async Task<IActionResult> GetExperience(int id)
        {
            var person = await _experienceRepository.GetExperience(id);
            if (person != null) return Ok(person);
            else
                return NotFound();
        }

        [HttpPost("AddExperience")]
        public async Task<IActionResult> AddExperience(CreateWorkingExperienceDto request)
        {
            var person = await _experienceRepository.AddExperience(request);
            if (person != null) return Ok("Experience Successfully added");
            else
                return NotFound();
        }

        [HttpPut("UpdateExperience/{experienceId}")]
        public async Task<IActionResult> UpdateExperience(int experienceId, [FromBody] CreateWorkingExperienceDto request)
        {
            var experience = await _experienceRepository.UpdateExperience(experienceId, request);
            if (experience != null) return Ok(experience);
            else
                return NotFound();
        }

        [HttpDelete("DeleteExperience/{id}")]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            var person = await _experienceRepository.DeleteExperience(id);
            if (person != null) return Ok("Experience Successfully Deleted");
            else
                return NotFound();
        }
    }
}
