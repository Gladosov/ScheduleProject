using System.ComponentModel.DataAnnotations;

namespace ScheduleProject.BLL.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}