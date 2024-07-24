using SchoolManagmentSystem.Server.Models;

namespace SchoolManagmentSystem.Server.Abstraction
{
    public interface IClassRepository
    {
        Task<List<Class>> ListSchoolClassesAsync(int classId);
        Task<Class> GetSchoolClassByIdAsync(int classId);
        Task<Class> CreateSchoolClassAsync(int schoolId, Class createClass);
        Task<Class> UpdateSchoolClassAsync(int schoolId, Class updatedClass);
        Task<Class> DeleteSchoolClassAsync(int schoolId, int classId);
        Task<int> GetNumberOfClassesBySchoolByIdAsync(int schoolId);
    }
}
