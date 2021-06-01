using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleProject.BLL.DTOs;
using ScheduleProject.DAL.Entities;
using ScheduleProject.BLL.Interfaces;
using ScheduleProject.BLL.Role;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ScheduleProject.WEB.Controller
{
    [Authorize]
    [Route("api/Schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;

        private readonly IMapper _mapper;

        public ScheduleController(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;

            _mapper = mapper;
        }

        [Authorize(Roles = Role.Student)]
        [HttpGet("ShowMySubjects")]
        public async Task<ActionResult<IEnumerable<ScheduleModel>>> ShowMySubjects()
        {
            var schedule = await _scheduleRepository.ShowMySubjects(User.FindFirstValue(ClaimTypes.GroupSid));

            if (schedule == null) return NotFound("Oops, something went wrong...");
            return Ok(_mapper.Map<IEnumerable<ScheduleDTO>>(schedule));
        }

        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpGet("ShowGroupsSubjects")]
        public async Task<ActionResult<IEnumerable<ScheduleModel>>> ShowGroupsSbjects(string Group)
        {
            var schedule = await _scheduleRepository.ShowMySubjects(Group);
            if (schedule == null) return NotFound("Oops, something went wrong...");
            return Ok(_mapper.Map<IEnumerable<ScheduleDTO>>(schedule));
        }

        [Authorize(Roles = Role.Student)]
        [HttpGet("ShowMySubjectsByDay")]
        public async Task<ActionResult<IEnumerable<ScheduleModel>>> ShowMySubjectsByDay(int day)
        {
            var schedule = await _scheduleRepository.ShowMySubjectsByDay(User.FindFirstValue(ClaimTypes.GroupSid), day);
            if (schedule == null) return NotFound("Oops, something went wrong...");
            return Ok(_mapper.Map<IEnumerable<ScheduleDTO>>(schedule));
        }

        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpPost("AddEvent")]
        public ActionResult AddEvent(EventAddDTO newEvent)
        {
            var Event = _scheduleRepository.AddEvent(newEvent);
            if (Event == null) return BadRequest("Error : maybe this time is scheduled");
            return StatusCode(201);
        }

        [Authorize(Roles = "Admin , SuperAdmin")]
        [HttpPost("DeleteEventByID")]
        public async Task<ActionResult> DeleteEventByID(int Id)
        {
            var callback = await _scheduleRepository.DeleteSubjectByID(Id);
            if (callback) return Ok("Record succesfully deleted");
            return BadRequest("Something wen wrong");
        }
    }
}