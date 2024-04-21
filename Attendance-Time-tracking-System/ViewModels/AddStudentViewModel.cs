using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System
{
    public class AddStudentViewModel
    {
        public AddStudentViewModel()
        {
            student = new Student();
            StudentTrackIntake = new StudentTrackIntake();
        }
        public Student student { get; set; }
        public StudentTrackIntake StudentTrackIntake { get; set; }
    }
}
