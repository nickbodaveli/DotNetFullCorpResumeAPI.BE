using FullCorp.Models.Dto.Experience;
using FullCorp.Models.Dto.Person;
using FullCorp.Models.Dto.User;

namespace FullCorp.Models.Dto.Applicant
{
    public class CreateApplicantDto
    {
        public CreatePersonDto Person { get; set; }
        public List<WorkingExperienceDto> WorkingExperiences { get; set; }
    }
}
