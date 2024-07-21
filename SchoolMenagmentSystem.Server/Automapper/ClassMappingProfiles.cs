using AutoMapper;
using SchoolManagmentSystem.Server.Dtos;
using SchoolManagmentSystem.Server.Models;
using SchoolMenagmentSystem.Server.Dtos;
using SchoolMenagmentSystem.Server.Models;

namespace SchoolManagmentSystem.Server.Automapper
{
    public class ClassMappingProfiles : Profile
    {
        public ClassMappingProfiles()
        {
            CreateMap<ClassCreateDto, Class>();
            CreateMap<Class, ClassGetDto>();
        }
    }
}
