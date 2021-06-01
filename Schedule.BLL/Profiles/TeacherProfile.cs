using AutoMapper;
using ScheduleProject.BLL.DTOs;
using ScheduleProject.DAL.Entities;

namespace ScheduleProject.BLL.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Users, TeacherDTO>();
        }
    }
}