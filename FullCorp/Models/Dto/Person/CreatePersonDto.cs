using FullCorp.Models.Dto.Experience;

namespace FullCorp.Models.Dto.Person
{
    public class CreatePersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Skype { get; set; }
        public string About { get; set; }
        public int UsersId { get; set; }
    }
}
