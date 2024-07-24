using SchoolManagmentSystem.Server.Models;

namespace SchoolManagmentSystem.Server.Abstraction
{
    public interface IAddressRepository
    {
        Task<Address> CreateAddressToSchoolAsync(int schoolId, Address address);
        Task<Address> UpdateAddressForSchoolAsync(int schoolId, Address updatedAddress);
        Task<Address> GetAddressForSchoolByIdAsync(int schoolId);
        Task<Address> DeleteAddressForSchoolAsync(int schoolId);
    }
}
