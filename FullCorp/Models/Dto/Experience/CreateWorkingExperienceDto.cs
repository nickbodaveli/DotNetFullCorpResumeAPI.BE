namespace FullCorp.Models.Dto.Experience
{
    public class CreateWorkingExperienceDto
    {
        public int Id { get; set; }
        public int PersonsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public bool IsPresent { get; set; }
    }
}
