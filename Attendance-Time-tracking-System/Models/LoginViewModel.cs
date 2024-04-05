using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.Models
{
    public class LoginViewModel
    {
		[Required(ErrorMessage = "Email is required")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public bool KeepLoggedIn { get; set; }
    }
}
