using FullCorp.Models.Entity.Auth;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FullCorp.Models.Entity
{
    public class Person
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Website { get; set; }
        public string Skype { get; set; }
        public string About { get; set; }
        [JsonIgnore] public User Users { get; set; }
        [JsonIgnore] public List<WorkingExperience> WorkingExperiences { get; set; }
        [JsonIgnore] public List<Skill> Skills { get; set; }
    }
}
