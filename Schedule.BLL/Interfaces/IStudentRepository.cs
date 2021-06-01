using ScheduleProject.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleProject.BLL.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Users>> GetStudents();

        Task<IEnumerable<Users>> GetStudentByID(int ID);

        Task<IEnumerable<Users>> GetStudentsByGroup(string Group);

        Task<IEnumerable<Users>> ShowMyGroupmates(string Group);
    }
}