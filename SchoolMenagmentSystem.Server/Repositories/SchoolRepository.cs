﻿using Microsoft.EntityFrameworkCore;
using SchoolMenagmentSystem.Server.Abstraction;
using SchoolMenagmentSystem.Server.Data;
using SchoolMenagmentSystem.Server.Models;
using System;

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

        public async Task<School> DeleteSchooldAsync(int id)
        {
            var school = await _context.Schools.FirstOrDefaultAsync(x => x.SchoodId == id);

            if(school == null)
            {
                return null;
            }

            _context.Schools.Remove(school);

            await _context.SaveChangesAsync();

            return school;
        }

        public async Task<List<School>> GetAllSchoolAsync()
        {
            var query = await _context.Schools.ToListAsync();

            return query;
        }

        public async Task<School> GetSchoolbyIdAsync(int id)
        {
            var school = await _context.Schools.FirstOrDefaultAsync(x => x.SchoodId == id);

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
