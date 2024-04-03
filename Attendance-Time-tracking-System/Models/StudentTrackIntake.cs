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
        public virtual Student Student { get; set; }
        public virtual Track Track { get; set; }
        public virtual Intake Intake { get; set; }
    }
}
