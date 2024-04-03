using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.Models
{
    public class StudentTrackIntake
    {
        public int StudentID { get; set; }
        public int TrackID { get; set; }
        [Required]
        public int IntakeID { get; set; }
    }
}
