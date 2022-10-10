using FullCorp.Interfaces;
using FullCorp.Models.Dto.Education;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCorp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationRepository _educationRepository;

        public EducationController(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        [HttpGet("GetEducations")]
        public async Task<IActionResult> GetEducations()
        {
            var education = await _educationRepository.GetEducations();
            if (education != null) return Ok(education);
            else
                return NotFound();
        }

        [HttpGet("GetEducation/{id}")]
        public async Task<IActionResult> GetEducation(int id)
        {
            var education = await _educationRepository.GetEducation(id);
            if (education != null) return Ok(education);
            else
                return NotFound();
        }

        [HttpPost("AddEducation")]
        public async Task<IActionResult> AddEducation(CreateEducationDto request)
        {
            var education = await _educationRepository.AddEducation(request);
            if (education != null) return Ok(education);
            else
                return NotFound();
        }

        [HttpPut("UpdateEducation/{educationId}")]
        public async Task<IActionResult> UpdateEducation(int educationId, [FromBody] CreateEducationDto request)
        {
            var education = await _educationRepository.UpdateEducation(educationId, request);
            if (education != null) return Ok(education);
            else
                return NotFound();
        }

        [HttpDelete("DeleteEducation/{id}")]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            var education = await _educationRepository.DeleteEducation(id);
            if (education != null) return Ok(education);
            else
                return NotFound();
        }
    }
}
