using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolManagmentSystem.Server.Enums;
using SchoolMenagmentSystem.Server.Abstraction;
using SchoolMenagmentSystem.Server.Data;
using SchoolMenagmentSystem.Server.Models;
using System;
using System.Linq;

namespace SchoolMenagmentSystem.Server.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly DataContext _context;
        public SchoolRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<School> CreateSchoolAsync(School school)
        {
            _context.Schools.Add(school);

            await _context.SaveChangesAsync();

            return school;
        }

        public async Task<School> DeleteSchooldAsync(int schoolId)
        {
            var school = await _context.Schools.FirstOrDefaultAsync(x => x.SchoolId == schoolId);

            _context.Schools.Remove(school);

            await _context.SaveChangesAsync();

            return school;
        }

        public async Task<List<School>> GetAllSchoolAsync(string searchTerm, List<SchoolType> enumSchool)
        {
            IQueryable<School> query = _context.Schools;

            if (!searchTerm.IsNullOrEmpty())
            {
                query = query.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()));
            }

            if (!enumSchool.IsNullOrEmpty())
            {
                query = query.Where(x => enumSchool.Contains(x.Type));
            }

            return query.ToList();
        }

        public async Task<School> GetSchoolbyIdAsync(int schoolId)
        {
            var school = await _context.Schools.FirstOrDefaultAsync(x => x.SchoolId == schoolId);

            if(school == null)
            {
                return null;
            }

            return school;
        }

        public async Task<School> UpdateSchoolAsync(School updateSchool)
        {
            _context.Schools.Update(updateSchool);

            await _context.SaveChangesAsync();

            return updateSchool;
        }
    }
}
