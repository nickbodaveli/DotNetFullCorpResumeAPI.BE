using FullCorp.Models.Dto.Education;
using FullCorp.Models.Entity;

namespace FullCorp.Interfaces
{
    public interface IEducationRepository
    {
        Task<List<EducationDto>> GetEducations();
        Task<List<EducationDto>> GetEducation(int id);
        Task<bool> AddEducation(CreateEducationDto request);
        Task<bool> UpdateEducation(int personId, CreateEducationDto request);
        Task<bool> DeleteEducation(int id);
    }
}
