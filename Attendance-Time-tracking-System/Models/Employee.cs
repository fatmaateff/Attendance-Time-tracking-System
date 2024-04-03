using System.ComponentModel.DataAnnotations;

using Microsoft.Build.Framework;

namespace Attendance_Time_tracking_System.Models
{
    public class Employee : User
    {
        [Required]
        public int Type { get; set; }
    }
}
