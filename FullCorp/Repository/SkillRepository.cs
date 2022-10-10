using FullCorp.Context;
using FullCorp.Interfaces;
using FullCorp.Models.Dto.Skills;
using FullCorp.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace FullCorp.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _context;

        public SkillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SkillDto>> GetSkills()
        {
            var skillTable = await (from skill in _context.Skills
                                        select skill).ToListAsync();

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

            return skillList;
        }

        public async Task<List<SkillDto>> GetSkill(int id)
        {
            var skillTable = await (from skill in _context.Skills
                                        where skill.Id == id
                                        select skill).ToListAsync();

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
            return skillList;
        }
        public async Task<bool> AddSkill(CreateSkillDto request)
        {
            var skill = new Skill()
            {
                Id = request.Id,
                PersonsId = request.PersonsId,
                Name = request.Name
            };

            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateSkill(int skillId, CreateSkillDto request)
        {
            var skillTable = await (from skill in _context.Skills
                                    where skill.Id == skillId
                                    select skill).FirstOrDefaultAsync();

            if (skillTable != null)
            {
                _context.Skills.Remove(skillTable);
                await _context.SaveChangesAsync();
            }

            var updatedSkill = new Skill()
            {
                PersonsId = request.PersonsId,
                Name = request.Name
            };

            _context.Skills.Add(updatedSkill);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteSkill(int id)
        {
            var result = await (from skill
                              in _context.Skills
                                where skill.PersonsId == id
                                select skill).FirstOrDefaultAsync();
            if (result != null)
            {
                _context.Skills.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
