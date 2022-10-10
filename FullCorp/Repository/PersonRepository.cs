using FullCorp.Context;
using FullCorp.Interfaces;
using FullCorp.Models.Dto.Education;
using FullCorp.Models.Dto.Experience;
using FullCorp.Models.Dto.Person;
using FullCorp.Models.Dto.Skills;
using FullCorp.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace FullCorp.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PersonDto>> GetAllPersons()
        {
            var persons = await (from person in _context.Persons
                                 select person).ToListAsync();

            List<PersonDto>? personDto = null;

            if (persons != null)
            {
                personDto = new List<PersonDto>();

                foreach (var person in persons)
                {
                    var existPerson = new PersonDto();
                    existPerson.Id = person.Id;
                    existPerson.UsersId = person.UsersId;
                    existPerson.Name = person.Name;
                    existPerson.About = person.About;
                    existPerson.LastName = person.LastName;
                    existPerson.Email = person.Mail;
                    existPerson.Skype = person.Skype;
                    existPerson.Phone = person.Phone;
                    existPerson.Website = person.Website;

                    var workingExperienceTable = await (from workingExperience in _context.WorkingExperience
                                                            where workingExperience.PersonsId == existPerson.Id
                                                            select workingExperience).ToListAsync();

                        if (workingExperienceTable != null)
                        {

                            foreach (var workingExp in workingExperienceTable)
                            {
                                existPerson.WorkingExperiences = new List<WorkingExperienceDto>();
                                existPerson.WorkingExperiences.Add(
                                    new WorkingExperienceDto()
                                    {
                                        Id = workingExp.Id,
                                        PersonsId = workingExp.PersonsId,
                                        Name = workingExp.Name,
                                        Description = workingExp.Description,
                                        StartDate = workingExp.StartDate,
                                        FinishDate = workingExp.FinishDate,
                                        IsPresent = workingExp.IsPresent,
                                    });
                            }
                        }

                    var educationTable = await (from education in _context.Educations
                                                        where education.PersonsId == existPerson.Id
                                                        select education).ToListAsync();

                    if (educationTable != null)
                    {

                        foreach (var singleEducation in educationTable)
                        {
                            existPerson.Educations = new List<EducationDto>();
                            existPerson.Educations.Add(
                                new EducationDto()
                                {
                                    Id = singleEducation.Id,
                                    PersonsId = singleEducation.PersonsId,
                                    Name = singleEducation.Name,
                                    Description = singleEducation.Description,
                                    StartDate = singleEducation.StartDate,
                                    FinishDate = singleEducation.FinishDate,
                                    IsPresent = singleEducation.IsPresent,
                                });
                        }
                    }

                    var skillTable = await (from skill in _context.Skills
                                                where skill.PersonsId == existPerson.Id
                                                select skill).ToListAsync();

                    if (skillTable != null)
                    {

                        foreach (var singleSkill in skillTable)
                        {
                            existPerson.Skills = new List<SkillDto>();
                            existPerson.Skills.Add(
                                new SkillDto()
                                {
                                    Id = singleSkill.Id,
                                    PersonsId = singleSkill.PersonsId,
                                    Name = singleSkill.Name
                                });
                        }
                    }
                    personDto.Add(existPerson);
                }
            }

            return personDto;

        }

        public async Task<PersonDto> GetPerson(int personId)
        {
            var result = await (from person in _context.Persons
                                where person.Id == personId
                                select person).FirstOrDefaultAsync();
            PersonDto personDto = null;

            if (result != null)
            {
                personDto = new PersonDto()
                {
                    Id = result.Id,
                    UsersId = result.UsersId,
                    Name = result.Name,
                    About = result.About,
                    LastName = result.LastName,
                    Email = result.Mail,
                    Skype = result.Skype,
                    Phone = result.Phone,
                    Website = result.Website

                };

                    var result2 = await (from workingExperience in _context.WorkingExperience
                                         where workingExperience.PersonsId == personId
                                         select workingExperience).ToListAsync();
                if(result2 != null)
                {

                    var workExp = new List<WorkingExperienceDto>();
                    foreach (var item in result2)
                    {
                        workExp.Add(
                                new WorkingExperienceDto()
                                {
                                    Id = item.Id,
                                    PersonsId = item.PersonsId,
                                    Name = item.Name,
                                    Description = item.Description,
                                    StartDate = item.StartDate,
                                    FinishDate = item.FinishDate,
                                    IsPresent = item.IsPresent
                                }
                            );
                    }
                    personDto.WorkingExperiences = workExp;
                }

                var educationTable = await (from education in _context.Educations
                                            where education.PersonsId == personId
                                            select education).ToListAsync();

                if (educationTable != null)
                {
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
                                            IsPresent = singleEducation.IsPresent,
                                        });
                    }
                    personDto.Educations = educationList;
                }

                var skillTable = await (from skill in _context.Skills
                                        where skill.PersonsId == personId
                                        select skill).ToListAsync();

                if (skillTable != null)
                {
                    var skillList = new List<SkillDto>();

                    foreach (var singleSkill in skillTable)
                    {
                        skillList.Add(
                            new SkillDto()
                            {
                                Id = singleSkill.Id,
                                PersonsId = singleSkill.PersonsId,
                                Name = singleSkill.Name
                            });
                    }
                    personDto.Skills = skillList;
                }
            }

            return personDto;
        }

        public async Task<int> GetPersonByUserId(int userId)
        {
            var result = await (from person in _context.Persons
                                where person.UsersId == userId
                                select person).FirstOrDefaultAsync();

            return result.Id;
        }

        public async Task<bool> AddPerson(CreatePersonDto request)
        {
            var searchPerson = await (from person in _context.Persons where person.UsersId == request.UsersId select person).FirstOrDefaultAsync();

            if (searchPerson == null && request != null)
            {
                //var person = new Person()
                //{
                //    UsersId = request.UsersId,
                //    Name = request.Name
                //};

                //_context.Persons.Add(person);
                //await _context.SaveChangesAsync();

                //var experience = new Experience()
                //{
                //    PersonsId = person.Id
                //};

                //_context.Experiences.Add(experience);
                //await _context.SaveChangesAsync();

                //foreach (var workExp in request.WorkingExperiences)
                //{
                //    var workingExperience = new WorkingExperience()
                //    {
                //        ExperiencesId = experience.Id,
                //        Name = workExp.Name
                //    };
                //    _context.WorkingExperience.Add(workingExperience);
                //    await _context.SaveChangesAsync();
                //}


                var result = new Person()
                {
                    UsersId = request.UsersId,
                    Name = request.Name,
                    LastName = request.LastName,
                    About = request.About,
                    Mail = request.Email,
                    Phone = request.Phone,
                    Website = request.Website,
                    Skype = request.Skype
                };

                _context.Persons.Add(result);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> UpdatePerson(int id, CreatePersonDto request)
        {
            var result = await (from person in _context.Persons
                                where person.Id == id
                                select person).FirstOrDefaultAsync();
            if(result != null)
            {
                
                result.Name = request.Name;
                result.LastName = request.LastName;
                result.About = request.About;
                result.Skype = request.Skype;
                result.Mail = request.Email;
                result.Phone = request.Phone;
                result.UsersId = request.UsersId;

                //result.UsersId = result.UsersId;
                //result.Name = request.Name;

                //_context.Persons.Update(result);
                ////await _context.SaveChangesAsync();

                //var result1 = await (from experience in _context.Experiences
                //                    where experience.PersonsId == result.Id
                //                     select experience).FirstOrDefaultAsync();

                //var result2 = await (from workingExperience in _context.WorkingExperience
                //                     where workingExperience.ExperiencesId == result1.Id
                //                     select workingExperience).ToListAsync();
                //foreach (var item in result2)
                //{
                //    item.Name = request.Name;
                //    _context.WorkingExperience.Update(item);
                //    //await _context.SaveChangesAsync();
                //}
                //await _context.SaveChangesAsync();
                //return true;

                _context.Persons.Update(result);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> DeletePerson(int id)
        {
            var result = await (from person in _context.Persons
                                where person.Id == id
                                select person).FirstOrDefaultAsync();
            if (result != null)
            {
                _context.Persons.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
