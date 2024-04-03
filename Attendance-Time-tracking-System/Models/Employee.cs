using System.ComponentModel.DataAnnotations;

using Microsoft.Build.Framework;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace Attendance_Time_tracking_System.Models
{
    public class Employee : User
    {
        [Required]
        public int Type { get; set; }
    }
}
