using SchoolManagmentSystem.Server.Models;

namespace SchoolManagmentSystem.Server.Abstraction
{
    public interface IGymnasticsHallRepository
    {
        Task<List<GymnasticsHall>> ListGymnasticsHallsAsync(int schoolId);
        Task<GymnasticsHall> GetGymnasticsHallByIdAsync(int hallId);
        Task<GymnasticsHall> CreateGymnasticsHallAsync(int schoolId, GymnasticsHall createHall);
        Task<GymnasticsHall> UpdateGymnasticsHallAsync(int schoolId, GymnasticsHall updatedHall);
        Task<GymnasticsHall> DeleteGymnasticsHallAsync(int schoolId, int hallId);
        Task<int> GetNumberOfGymnasticsHallsBySchoolByIdAsync(int schoolId);
    }
}
