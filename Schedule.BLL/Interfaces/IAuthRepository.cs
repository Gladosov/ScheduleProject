using ScheduleProject.DAL.Entities;

namespace ScheduleProject.BLL.Interfaces
{
    public interface IAuthRepository
    {
        Users Register(Users student, string password);

        Users Login(string username, string password);

        bool UserExists(string username);
    }
}