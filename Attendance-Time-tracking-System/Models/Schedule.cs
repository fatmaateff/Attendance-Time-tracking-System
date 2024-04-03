using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.Models
{
    public class Schedule
    {
        public int ID { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        [MaxLength(20)]
        public string Subject { get; set; }

    }
}
