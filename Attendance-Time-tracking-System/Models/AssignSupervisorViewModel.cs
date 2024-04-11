using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.Models
{
    public class AssignSupervisorViewModel
    {
        [Required(ErrorMessage = "Please select a track.")]
        public int TrackId { get; set; }

        [Required(ErrorMessage = "Please select an instructor.")]
        public int InstructorId { get; set; }

        [Required(ErrorMessage = "Please select an intake.")]
        public int IntakeId { get; set; }

        [Required(ErrorMessage = "Please select a branch.")]
        public int BranchId { get; set; }
    }



}

