using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        [MaxLength(20)]
        public string Subject { get; set; }

        //navigation properties
        public virtual ICollection<TrackSchedule> TrackSchedules { get; set; }

    }
}
