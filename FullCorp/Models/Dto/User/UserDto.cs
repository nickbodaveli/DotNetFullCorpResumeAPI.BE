using FullCorp.Models.Dto.Person;
using FullCorp.Models.Entity.Auth;
using System.Text.Json.Serialization;

namespace FullCorp.Models.Dto.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public bool AgreeTerm { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        //public bool RememberMe { get; set; }
        //[NotMapped]
        //public string? Token { get; set; }
        //[NotMapped]
        //public string? AppOriginUrl { get; set; }
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
        public int? TenantId { get; set; }
        public Tenant? Tenant { get; set; }
        public List<PersonDto> Persons { get; set; }
    }
}
