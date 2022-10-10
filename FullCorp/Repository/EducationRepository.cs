using FullCorp.Context;
using FullCorp.Interfaces;
using FullCorp.Models.Dto.Education;
using FullCorp.Models.Dto.Experience;
using FullCorp.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace FullCorp.Repository
{
    public class EducationRepository : IEducationRepository
    {
        private readonly ApplicationDbContext _context;

        public EducationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EducationDto>> GetEducations()
        {
            var educationTable = await (from education in _context.Educations
                                               select education).ToListAsync();

            var educationList = new List<EducationDto>();

            foreach (var singleEducation in educationTable)
            {

                educationList.Add(
                    new EducationDto()
                    {
                        Id = singleEducation.Id,
                        PersonsId = singleEducation.PersonsId,
                        Name = singleEducation.Name,
                        Description = singleEducation.Description,
                        StartDate = singleEducation.StartDate,
                        FinishDate = singleEducation.FinishDate,
                        IsPresent = singleEducation.IsPresent
                    });
            }

            return educationList;
        }

        public async Task<List<EducationDto>> GetEducation(int id)
        {
            var educationTable = await (from education in _context.Educations
                                               where education.PersonsId == id
                                               select education).ToListAsync();

            var educationList = new List<EducationDto>();

            foreach (var singleEducation in educationTable)
            {

                educationList.Add(
                    new EducationDto()
                    {
                        Id = singleEducation.Id,
                        PersonsId = singleEducation.PersonsId,
                        Name = singleEducation.Name,
                        Description = singleEducation.Description,
                        StartDate = singleEducation.StartDate,
                        FinishDate = singleEducation.FinishDate,
                        IsPresent = singleEducation.IsPresent
                    });
            }
            return educationList;
        }
        public async Task<bool> AddEducation(CreateEducationDto request)
        {
            var education = new Education()
            {
                Id = request.Id,
                PersonsId = request.PersonsId,
                Name = request.Name,
                Description = request.Description,
                StartDate = request.StartDate,
                FinishDate = request.FinishDate,
                IsPresent = request.IsPresent
            };

            _context.Educations.AddRange(education);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateEducation(int educationId, CreateEducationDto request)
        {
            var educationTable = await (from education in _context.Educations
                                               where education.Id == educationId
                                        select education).ToListAsync();

            if (educationTable != null)
            {
                foreach (var item in educationTable)
                {
                    _context.Educations.Remove(item);
                    await _context.SaveChangesAsync();
                }
            }

            var educations = new Education()
            {
                PersonsId = educationId,
                Name = request.Name,
                Description = request.Description,
                StartDate = request.StartDate,
                FinishDate = request.FinishDate,
                IsPresent = request.IsPresent
            };

            _context.Educations.Add(educations);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteEducation(int id)
        {
            var result = await(from education
                              in _context.Educations
                               where education.PersonsId == id
                               select education).FirstOrDefaultAsync();
            if (result != null)
            {
                _context.Educations.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}
