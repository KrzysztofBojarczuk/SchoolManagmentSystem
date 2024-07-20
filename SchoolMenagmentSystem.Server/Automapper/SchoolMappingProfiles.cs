using AutoMapper;
using SchoolMenagmentSystem.Server.Dtos;
using SchoolMenagmentSystem.Server.Models;

namespace SchoolMenagmentSystem.Server.Automapper
{
    public class SchoolMappingProfiles : Profile
    {
        public SchoolMappingProfiles()
        {
            CreateMap<SchoolCreateDto, School>();
            CreateMap<School, SchoolGetDto>();
        }
    }
}
