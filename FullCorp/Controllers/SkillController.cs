using FullCorp.Interfaces;
using FullCorp.Models.Dto.Skills;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCorp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillRepository _skillRepository;

        public SkillController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        [HttpGet("GetSkills")]
        public async Task<IActionResult> GetSkills()
        {
            var skill = await _skillRepository.GetSkills();
            if (skill != null) return Ok(skill);
            else
                return NotFound();
        }

        [HttpGet("GetSkill/{id}")]
        public async Task<IActionResult> GetSkill(int id)
        {
            var skill = await _skillRepository.GetSkill(id);
            if (skill != null) return Ok(skill);
            else
                return NotFound();
        }

        [HttpPost("AddSkill")]
        public async Task<IActionResult> AddPerson([FromBody] CreateSkillDto request)
        {
            var skill = await _skillRepository.AddSkill(request);
            if (skill != null) return Ok(skill);
            else
                return NotFound();
        }

        [HttpPut("UpdateSkill/{id}")]
        public async Task<IActionResult> UpdateAddSkill(int id, [FromBody] CreateSkillDto request)
        {
            var skill = await _skillRepository.UpdateSkill(id, request);
            if (skill != null) return Ok(skill);
            else
                return NotFound();
        }

        [HttpDelete("DeleteEducation/{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var skill = await _skillRepository.DeleteSkill(id);
            if (skill != null) return Ok(skill);
            else
                return NotFound();
        }
    }
}
