//using FullCorp.Context;
//using FullCorp.Interfaces;
//using FullCorp.Models.Dto.Applicant;
//using FullCorp.Models.Dto.Experience;
//using FullCorp.Models.Dto.Person;
//using FullCorp.Models.Dto.User;
//using FullCorp.Models.Entity;
//using Microsoft.EntityFrameworkCore;

//namespace FullCorp.Repository
//{
//    public class ApplicantRepository : IApplicantRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public ApplicantRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }
//        public async Task<List<ApplicantDto>> GetApplicants()
//        {
//            var result = await (from user in _context.Users
//                                join person in _context.Persons on user.Id equals person.UsersId
//                                join expeience in _context.Experiences on person.Id equals expeience.PersonsId
//                                join work in _context.WorkingExperience on expeience.Id equals work.ExperiencesId
//                                //into wexp
//                                //from m in wexp.DefaultIfEmpty()
//                                select new ApplicantDto
//                                {
//                                    Users = new List<UserDto>()
//                                    {
//                                       new UserDto()
//                                       {
//                                           Id = user.Id,
//                                           Email = user.Email,
//                                           Persons = new List<PersonDto>()
//                                           {
//                                               new PersonDto()
//                                               {
//                                                   Id = person.Id,
//                                                   UsersId = person.UsersId,
//                                                   Name = person.Name,
//                                                   Experiences = new List<ExperienceDto>()
//                                                   {
//                                                       new ExperienceDto()
//                                                       {
//                                                           PersonsId = expeience.PersonsId,
//                                                           WorkingExperiences = new List<WorkingExperienceDto>()
//                                                           {
//                                                               new WorkingExperienceDto()
//                                                               {
//                                                                   Id = work.Id,
//                                                                   ExperiencesId = work.ExperiencesId,
//                                                                   Name = work.Name
//                                                               }
//                                                           }
//                                                       }
//                                                   }
//                                               }
//                                           }
//                                       }
//                                    }
//                                }).ToListAsync();
//            return result;

//        }

//        public async Task<bool> CreateApplicant(CreateApplicantDto param)
//        {
//            var searchPerson = await (from person in _context.Persons where person.UsersId == param.Person.UsersId select person).FirstOrDefaultAsync();

//            if (searchPerson == null && param != null)
//            {
//                var person = new Person()
//                {
//                    UsersId = param.Person.UsersId,
//                    Name = param.Person.Name
//                };

//                _context.Persons.Add(person);
//                await _context.SaveChangesAsync();

//                var experience = new Experience()
//                {
//                    PersonsId = person.Id
//                };

//                _context.Experiences.Add(experience);
//                await _context.SaveChangesAsync();

//                foreach (var workExp in param.WorkingExperiences)
//                {
//                    var workingExperience = new WorkingExperience()
//                    {
//                        ExperiencesId = experience.Id,
//                        Name = workExp.Name
//                    };
//                    _context.WorkingExperience.Add(workingExperience);
//                    await _context.SaveChangesAsync();
//                }
                
//                return true;
//            }

//            return false;
//        }

//        public async Task<bool> DeleteApplicant(int id)
//        {
//            var persons = await (from i in _context.Persons
//                                 where i.UsersId == id
//                                 select i).ToListAsync();

//            foreach (var experience in persons)
//            {
//                var experiences = await (from i in _context.Experiences
//                                         where i.PersonsId == experience.Id
//                                         select new ExperienceDto()
//                                         {
//                                            PersonsId = i.PersonsId
//                                         }).ToListAsync();

//                foreach (var workingExperience in experiences)
//                {
//                    foreach (var item in workingExperience.WorkingExperiences)
//                    {
//                        var working = await (from i in _context.WorkingExperience
//                                             where i.ExperiencesId == item.ExperiencesId
//                                             select i).FirstOrDefaultAsync();

//                        _context.WorkingExperience.Remove(working);
//                        await _context.SaveChangesAsync();
//                    }
//                }
//            }
//            return true;
//        }
//    }
//}
