using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.Models
{
    public class Program
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Duration { get; set; }
    }
}
