using ScheduleProject.BLL.DTOs;
using ScheduleProject.DAL.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleProject.BLL.Interfaces
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<ScheduleModel>> ShowMySubjects(string Group);

        Task<IEnumerable<ScheduleModel>> ShowMySubjectsByDay(string Group, int Day);

        ScheduleModel AddEvent(EventAddDTO newEvent);

        Task<bool> DeleteSubjectByID(int id);
    }
}