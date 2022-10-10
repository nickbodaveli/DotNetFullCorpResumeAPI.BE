using FullCorp.Models.Dto.Education;
using FullCorp.Models.Dto.Experience;
using FullCorp.Models.Dto.Skills;

namespace FullCorp.Models.Dto.Person
{
    public class PersonDto
    {
        public int? Id { get; set; }
        public int? UsersId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? Skype { get; set; }
        public string? About { get; set; }
        public List<WorkingExperienceDto>? WorkingExperiences { get; set; }
        public List<EducationDto>? Educations { get; set; }
        public List<SkillDto>? Skills { get; set; }
    }
}
