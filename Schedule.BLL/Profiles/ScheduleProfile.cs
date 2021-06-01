using AutoMapper;
using ScheduleProject.BLL.DTOs;
using ScheduleProject.DAL.Entities;

namespace ScheduleProject.BLL.Profiles
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<ScheduleModel, ScheduleDTO>();
            CreateMap<ScheduleModel, EventAddDTO>();
        }
    }
}