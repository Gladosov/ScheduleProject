using ScheduleProject.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleProject.BLL.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Users>> GetTeachers();

        Task<IEnumerable<Users>> GetTeacherByID(int ID);
    }
}