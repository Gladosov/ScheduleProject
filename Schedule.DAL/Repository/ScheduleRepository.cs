using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleProject.BLL.DTOs;
using ScheduleProject.BLL.Interfaces;
using ScheduleProject.DAL.Context;
using ScheduleProject.DAL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleProject.DAL.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly schedule_dbContext _dbContext;

        public ScheduleRepository(schedule_dbContext schedule_DbContext)
        {
            _dbContext = schedule_DbContext;
        }

        public ScheduleModel AddEvent(EventAddDTO newEvent)
        {
            var SubStart = TimeSpan.Parse(newEvent.SubjectStart);
            var SubEnd = TimeSpan.Parse(newEvent.SubjectEnd);

            var Event = new ScheduleModel
            {
                SubjectStart = SubStart,
                SubjectEnd = SubEnd,
                Day = newEvent.Day,
                Class = newEvent.Class,
                Group = newEvent.Group,
                Subject = newEvent.Subject,
                Teacher = newEvent.Teacher
            };

            if (_dbContext.Schedule.Any(x => x.Teacher.Equals(Event.Teacher) && x.Day.Equals(Event.Day) && (x.SubjectStart <= Event.SubjectStart && x.SubjectEnd >= Event.SubjectEnd))) return null;

            _dbContext.Schedule.Add(Event);
            _dbContext.SaveChanges();

            return Event;
        }

        public async Task<IEnumerable<ScheduleModel>> ShowMySubjects(string Group)
        {
            return await _dbContext.Schedule.Where(x => x.Group.Equals(Group)).ToArrayAsync();
        }

        public async Task<IEnumerable<ScheduleModel>> ShowMySubjectsByDay(string Group, int Day)
        {
            return await _dbContext.Schedule.Where(x => x.Group.Equals(Group)).Where(x => x.Day.Equals(Day)).ToListAsync();
        }

        public async Task<bool> DeleteSubjectByID(int id)
        {
            var delete = await _dbContext.Schedule.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (delete != null)
            {
                _dbContext.Schedule.Remove(delete);
                _dbContext.Entry(delete).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}