using System.Text.Json.Serialization;

namespace FullCorp.Models.Entity
{
    public class Skill
    {
        public int Id { get; set; }
        public int PersonsId { get; set; }
        public string Name { get; set; }
        [JsonIgnore] public Person Persons { get; set; }
    }
}
