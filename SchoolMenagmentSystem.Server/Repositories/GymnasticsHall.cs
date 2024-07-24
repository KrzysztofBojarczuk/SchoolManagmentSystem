using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.Server.Abstraction;
using SchoolManagmentSystem.Server.Models;
using SchoolMenagmentSystem.Server.Data;

namespace SchoolManagmentSystem.Server.Repositories
{
    public class GymnasticsHallRepository : IGymnasticsHallRepository
    {
        private readonly DataContext _context;

        public GymnasticsHallRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<GymnasticsHall>> ListGymnasticsHallsAsync(int schoolId)
        {
            return await _context.GymnasticsHalls.Where(x => x.SchoolId == schoolId).ToListAsync();
        }

        public async Task<GymnasticsHall> GetGymnasticsHallByIdAsync(int hallId)
        {
            return await _context.GymnasticsHalls.FirstOrDefaultAsync(x => x.GymnasticsHallId == hallId);
        }

        public async Task<GymnasticsHall> CreateGymnasticsHallAsync(int schoolId, GymnasticsHall createHall)
        {
            var school = await _context.Schools.Include(x => x.GymnasticsHalls).FirstOrDefaultAsync(x => x.SchoolId == schoolId);

            if (school == null)
            {
                return null;
            }

            school.GymnasticsHalls.Add(createHall);
            await _context.SaveChangesAsync();
            return createHall;
        }

        public async Task<GymnasticsHall> UpdateGymnasticsHallAsync(int schoolId, GymnasticsHall updatedHall)
        {
            var existingHall = await _context.GymnasticsHalls.FirstOrDefaultAsync(x => x.SchoolId == schoolId && x.GymnasticsHallId == updatedHall.GymnasticsHallId);

            if (existingHall == null)
            {
                return null;
            }

            existingHall.GymnasticsHallNumber = updatedHall.GymnasticsHallNumber;
            existingHall.Surface = updatedHall.Surface;
            existingHall.NeedsRepair = updatedHall.NeedsRepair;
            existingHall.BusyFrom = updatedHall.BusyFrom;
            existingHall.BusyTo = updatedHall.BusyTo;

            await _context.SaveChangesAsync();
            return existingHall;
        }

        public async Task<GymnasticsHall> DeleteGymnasticsHallAsync(int schoolId, int hallId)
        {
            var hallToDelete = await _context.GymnasticsHalls.FirstOrDefaultAsync(x => x.SchoolId == schoolId && x.GymnasticsHallId == hallId);

            if (hallToDelete == null)
            {
                return null;
            }

            _context.GymnasticsHalls.Remove(hallToDelete);
            await _context.SaveChangesAsync();
            return hallToDelete;
        }

        public async Task<int> GetNumberOfGymnasticsHallsBySchoolByIdAsync(int schoolId)
        {
            return await _context.GymnasticsHalls.CountAsync(x => x.SchoolId == schoolId);
        }
    }
}
