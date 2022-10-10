using FullCorp.Context;
using FullCorp.Interfaces;
using FullCorp.Models.Dto.Experience;
using FullCorp.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace FullCorp.Repository
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly ApplicationDbContext _context;

        public ExperienceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkingExperienceDto>> GetExperiences()
        {
                    var workingExperienceTable = await (from workingExperience in _context.WorkingExperience
                                                        select workingExperience).ToListAsync();

                    var workingExperiences = new List<WorkingExperienceDto>();

                    foreach (var workingExp in workingExperienceTable)
                    {

                            workingExperiences.Add(
                                new WorkingExperienceDto()
                                {
                                    Id = workingExp.Id,
                                    PersonsId = workingExp.PersonsId,
                                    Name = workingExp.Name,
                                    Description = workingExp.Description,
                                    StartDate = workingExp.StartDate,
                                    FinishDate = workingExp.FinishDate,
                                    IsPresent = workingExp.IsPresent
                                });
                    }

            return workingExperiences;
        }

        public async Task<List<WorkingExperienceDto>> GetExperience(int id)
        {
            var workingExperienceTable = await (from workingExperience in _context.WorkingExperience
                                                where workingExperience.PersonsId == id
                                                select workingExperience).ToListAsync();

            var workingExperiences = new List<WorkingExperienceDto>();

            foreach (var workingExp in workingExperienceTable)
            {

                workingExperiences.Add(
                    new WorkingExperienceDto()
                    {
                        Id = workingExp.Id,
                        PersonsId = workingExp.PersonsId,
                        Name = workingExp.Name,
                        Description = workingExp.Description,
                        StartDate = workingExp.StartDate,
                        FinishDate = workingExp.FinishDate,
                        IsPresent = workingExp.IsPresent
                    });
            }
            return workingExperiences;
        }

        public async Task<bool> AddExperience(CreateWorkingExperienceDto request)
        {
            var workingExperiences = new WorkingExperience()
            {
                Id = request.Id,
                PersonsId = request.PersonsId,
                Name = request.Name,
                Description = request.Description,
                StartDate = request.StartDate,
                FinishDate = request.FinishDate,
                IsPresent = request.IsPresent
            };
            _context.WorkingExperience.Add(workingExperiences);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateExperience(int experienceId, CreateWorkingExperienceDto request)
        {

            var workingExperienceTable = await (from workingExperience in _context.WorkingExperience
                                                where workingExperience.Id == experienceId
                                                select workingExperience).FirstOrDefaultAsync();

            if (workingExperienceTable != null)
            {
               
                _context.WorkingExperience.Remove(workingExperienceTable);
                await _context.SaveChangesAsync();
            }

            var experience = new WorkingExperience()
            {
                PersonsId = experienceId,
                Name = request.Name,
                Description = request.Description,
                StartDate = request.StartDate,
                FinishDate = request.FinishDate,
                IsPresent = request.IsPresent
            };

            _context.WorkingExperience.Add(experience);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteExperience(int id)
        {
            var result = await (from experience
                                in _context.WorkingExperience
                                where experience.PersonsId == id
                                select experience).FirstOrDefaultAsync();
            if (result != null)
            {
                _context.WorkingExperience.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
