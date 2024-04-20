using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Time_tracking_System.Models
{
    public class Student : User
    {
        [StringLength(100, MinimumLength = 2)]
        public string University { get; set; }
        [StringLength(100, MinimumLength = 2)]
        public string Faculty { get; set; }
        [StringLength(100, MinimumLength = 2)]
        public string Specialization { get; set; }
        public int GradYear { get; set; }

    }
}
