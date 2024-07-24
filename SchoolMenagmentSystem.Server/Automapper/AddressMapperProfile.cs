using AutoMapper;
using SchoolManagmentSystem.Server.Dtos;
using SchoolManagmentSystem.Server.Models;

namespace SchoolManagmentSystem.Server.Automapper
{
    public class AddressMapperProfile : Profile
    {
        public AddressMapperProfile()
        {
            CreateMap<AddressCreateDto, Address>();
            CreateMap<Address, AddressGetDto>();
        }
    }
}
