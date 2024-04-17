using Attendance_Time_tracking_System.Enums;
using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.Models
{
    public class Employee : User
    {
        [Required]
        public EmpType Type { get; set; }
    }
}
