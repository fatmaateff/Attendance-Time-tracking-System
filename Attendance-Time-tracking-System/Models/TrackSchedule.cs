using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Time_tracking_System.Models
{
    public class TrackSchedule
    {
        [ForeignKey("Schedule")]
        public int ScheduleID { get; set; }
        [ForeignKey("Intake")]
        public int IntakeID { get; set; }
        [Required, ForeignKey("Branch")]
        public int BranchID { get; set; }
        [Required, ForeignKey("Track")]
        public int TrackID { get; set; }

        //navigation properties
        public virtual Schedule Schedule { get; set; }
        public virtual Intake Intake { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Track Track { get; set; }
    }
}
