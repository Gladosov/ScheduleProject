using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleProject.BLL.DTOs;
using ScheduleProject.BLL.Interfaces;
using ScheduleProject.BLL.Role;
using ScheduleProject.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleProject.WEB.Controller
{
    [Authorize]
    [Route("api/Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public AdminController(ITeacherRepository teacherRepository, IMapper mapper, IUserRepository userRepository)
        {
            _teacherRepository = teacherRepository;
            _userRepository = userRepository;

            _mapper = mapper;
        }

        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpGet("GetAllTeachers")]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllTeachers()
        {
            var Teachers = await _teacherRepository.GetTeachers();
            if (Teachers == null) return NotFound("Oops, something went wrong...");
            return Ok(_mapper.Map<IEnumerable<TeacherDTO>>(Teachers));
        }

        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpGet("GetTeacherByID")]
        public async Task<ActionResult<IEnumerable<Users>>> GeTeacherID(int ID)
        {
            var Teacher = await _teacherRepository.GetTeacherByID(ID);
            if (Teacher == null) return NotFound("Oops, something went wrong...");
            return Ok(_mapper.Map<IEnumerable<TeacherDTO>>(Teacher));
        }

        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpPost("SetAsTeacher")]
        public async Task<ActionResult> SetAsTeacher(string Username)
        {
            var update = await _userRepository.SetAsTeacher(Username);
            if (update == false) return NotFound("Oops, something went wrong...");
            return Ok("Role changed");
        }

        [Authorize(Roles = Role.SuperAdmin)]
        [HttpPost("SetAsAdmin")]
        public async Task<ActionResult> SetAsAdmin(string Username)
        {
            var update = await _userRepository.SetAsAdmin(Username);
            if (update == false) return NotFound("Oops, something went wrong...");
            return Ok("Role changed");
        }
    }
}