using AutoMapper;
using ScheduleProject.BLL.DTOs;
using ScheduleProject.DAL.Entities;

namespace ScheduleProject.BLL.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Users, StudentDTO>();
        }
    }
}