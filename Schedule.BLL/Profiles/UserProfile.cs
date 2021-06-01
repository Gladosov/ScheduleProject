using AutoMapper;
using ScheduleProject.BLL.DTOs;
using ScheduleProject.DAL.Entities;

namespace ScheduleProject.BLL.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Users, UserRegisterDTO>();
            CreateMap<Users, UserLoginDTO>();
        }
    }
}