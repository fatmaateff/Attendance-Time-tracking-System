using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.Models
{
    public class TrackSupervisor
    {
        public int InstructorID { get; set; }
        public int IntakeID { get; set; }
        [Required]
        public int BranchID { get; set; }
        [Required]
        public int TrackID { get; set; }
    }
}
