using AutoMapper;
using SchoolManagmentSystem.Server.Dtos;
using SchoolManagmentSystem.Server.Models;

namespace SchoolManagmentSystem.Server.Automapper
{
    public class GymnasticsHallMappingProfile : Profile
    {
        public GymnasticsHallMappingProfile()
        {
            CreateMap<GymnasticsHallPostPutDto, GymnasticsHall>();
            CreateMap<GymnasticsHall, GymnasticsHallGetDto>();
        }
    }

}
