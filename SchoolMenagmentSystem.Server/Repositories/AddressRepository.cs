using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.Server.Abstraction;
using SchoolManagmentSystem.Server.Models;
using SchoolMenagmentSystem.Server.Data;

namespace SchoolManagmentSystem.Server.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AddressRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Address> GetAddressForSchoolByIdAsync(int schoolId)
        {
            var school = await _context.Schools
                          .Include(x => x.Addres)
                          .FirstOrDefaultAsync(x => x.SchoolId == schoolId);

            if (school == null)
            {
                return null;
            }

            return school.Addres;
        }

        public async Task<Address> UpdateAddressForSchoolAsync(int schoolId, Address updatedAddress)
        {
            var school = await _context.Schools.Include(x => x.Addres).FirstOrDefaultAsync(x => x.SchoolId == schoolId);

            if (school.Addres == null)
            {
                return null;
            }

            school.Addres.Street = updatedAddress.Street;
            school.Addres.City = updatedAddress.City;
            school.Addres.Number = updatedAddress.Number;
            school.Addres.ZipCode = updatedAddress.ZipCode;

            await _context.SaveChangesAsync();

            return school.Addres;
        }

        public async Task<Address> CreateAddressToSchoolAsync(int schoolId, Address address)
        {
            var school = await _context.Schools.FirstOrDefaultAsync(x => x.SchoolId == schoolId);

            if (school == null)
            {
                return null;
            }

            school.Addres = address;

            await _context.SaveChangesAsync();

            return address;
        }

        public async Task<Address> DeleteAddressForSchoolAsync(int schoolId)
        {
            var school = await _context.Schools.Include(x => x.Addres).FirstOrDefaultAsync(x => x.SchoolId == schoolId);

            if (school == null)
            {
                return null;
            }

            if (school.Addres == null)
            {
                return null;
            }

            var address = school.Addres;

            _context.Remove(address);
            await _context.SaveChangesAsync();

            return address;
        }
    }
}
