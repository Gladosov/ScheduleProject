using Microsoft.EntityFrameworkCore;
using ScheduleProject.DAL.Entities;
using ScheduleProject.BLL.Interfaces;
using ScheduleProject.DAL.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleProject.DAL.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly schedule_dbContext _dbContext;

        public StudentRepository(schedule_dbContext schedule_DbContext)
        {
            _dbContext = schedule_DbContext;
        }

        public async Task<IEnumerable<Users>> GetStudentsByGroup(string Group)
        {
            return await _dbContext.Users.Where(s => s.Role.Equals("Student")).Where(s => s.Group.Equals(Group)).ToListAsync();
        }

        public async Task<IEnumerable<Users>> GetStudentByID(int ID)
        {
            return await _dbContext.Users.Where(s => s.Role.Equals("Student")).Where(s => s.UserId.Equals(ID)).ToListAsync();
        }

        public async Task<IEnumerable<Users>> GetStudents()
        {
            return await _dbContext.Users.Where(s => s.Role.Equals("Student")).ToArrayAsync();
        }

        public async Task<IEnumerable<Users>> ShowMyGroupmates(string Group)
        {
            return await _dbContext.Users.Where(s => s.Group.Equals(Group)).ToArrayAsync();
        }
    }
}