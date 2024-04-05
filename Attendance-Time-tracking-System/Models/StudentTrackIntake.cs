using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Time_tracking_System.Models
{
    public class StudentTrackIntake
    {
        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [ForeignKey("Track")]
        public int TrackID { get; set; }

        [Required, ForeignKey("Intake")]
        public int IntakeID { get; set; }

        //navigation properties
        public Student Student { get; set; }
        public Track Track { get; set; }
        public Intake Intake { get; set; }
    }
}
