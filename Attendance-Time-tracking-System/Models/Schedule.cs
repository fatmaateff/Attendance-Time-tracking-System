using Attendance_Time_tracking_System.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        [Required]
        [UniqueScheduleDate]
        [DataType(DataType.Date)]
        public DateOnly Date { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name ="Start Time")]
        public TimeOnly StartTime { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        [TimeValidation]
        public TimeOnly EndTime { get; set; }
        [MinLength(2),MaxLength(20)]
        public string Subject { get; set; }

        //navigation properties
        public virtual ICollection<TrackSchedule> TrackSchedules { get; set; }

    }
}
