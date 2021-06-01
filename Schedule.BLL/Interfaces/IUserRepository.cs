using System.Threading.Tasks;

namespace ScheduleProject.BLL.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> SetAsTeacher(string Username);

        Task<bool> SetAsAdmin(string Username);
    }
}