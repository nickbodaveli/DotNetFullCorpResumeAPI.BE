using FullCorp.Models.Dto.Experience;
using FullCorp.Models.Entity;

namespace FullCorp.Interfaces
{
    public interface IExperienceRepository
    {
        Task<List<WorkingExperienceDto>> GetExperiences();
        Task<List<WorkingExperienceDto>> GetExperience(int id);
        Task<bool> AddExperience(CreateWorkingExperienceDto request);
        Task<bool> UpdateExperience(int experienceId, CreateWorkingExperienceDto request);
        Task<bool> DeleteExperience(int id);
    }
}
