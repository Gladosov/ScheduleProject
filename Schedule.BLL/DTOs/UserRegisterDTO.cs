using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleProject.BLL.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Password length must be between 8 and 15")]
        public string Password { get; set; }

        public String Group { get; set; }
    }
}