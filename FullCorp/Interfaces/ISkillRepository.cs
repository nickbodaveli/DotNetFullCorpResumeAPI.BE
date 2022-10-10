using FullCorp.Models.Dto.Skills;

namespace FullCorp.Interfaces
{
    public interface ISkillRepository
    {
        Task<List<SkillDto>> GetSkills();
        Task<List<SkillDto>> GetSkill(int id);
        Task<bool> AddSkill(CreateSkillDto request);
        Task<bool> UpdateSkill(int personId, CreateSkillDto request);
        Task<bool> DeleteSkill(int id);
    }
}
