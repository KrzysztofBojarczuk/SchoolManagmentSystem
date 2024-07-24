using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.Server.Abstraction;
using SchoolManagmentSystem.Server.Models;
using SchoolMenagmentSystem.Server.Data;
using SchoolMenagmentSystem.Server.Models;

namespace SchoolManagmentSystem.Server.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ClassRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Class>> ListSchoolClassesAsync(int schoolId)
        {
            return await _context.Classes.Where(x => x.SchoolId == schoolId).ToListAsync();
        }

        public async Task<Class> GetSchoolClassByIdAsync( int classId)
        {
            return await _context.Classes.FirstOrDefaultAsync(x => x.ClassId == classId);
        }

        public async Task<Class> CreateSchoolClassAsync(int schoolId, Class createClass)
        {
            var school = await _context.Schools.Include(x => x.Clases).FirstOrDefaultAsync(x => x.SchoolId == schoolId);

            if (school == null)
            {
                return null;
            }

            school.Clases.Add(createClass);

            await _context.SaveChangesAsync();
            return createClass;
        }

        public async Task<Class> UpdateSchoolClassAsync(int schoolId, Class updatedClass)
        {
            var existingClass = await _context.Classes.FirstOrDefaultAsync(x => x.SchoolId == schoolId && x.ClassId == updatedClass.ClassId);

            existingClass.ClassName = updatedClass.ClassName;
            existingClass.GradeLevel = updatedClass.GradeLevel;

            await _context.SaveChangesAsync();

            return existingClass;
        }

        public async Task<Class> DeleteSchoolClassAsync(int schoolId, int classId)
        {
            var classToDelete = await _context.Classes.FirstOrDefaultAsync(x => x.SchoolId == schoolId && x.ClassId == classId);

            if (classToDelete == null)
            {
                return null;
            }

            _context.Classes.Remove(classToDelete);
            await _context.SaveChangesAsync();

            return classToDelete;
        }

        public async Task<int> GetNumberOfClassesBySchoolByIdAsync(int schoolId)
        {
            var numberOfSchool = await _context.Classes.Where(x => x.SchoolId == schoolId).CountAsync();

            return numberOfSchool;
        }
    }
}
