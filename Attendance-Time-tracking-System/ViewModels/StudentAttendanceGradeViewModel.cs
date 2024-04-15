using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.ViewModels
{
    public class StudentAttendanceGradeViewModel
    {
        public List<Attendance> attendances;
        public int Late { get; set; }
        public int Absent { get; set; }
        public int Grade { get; set; }
    }
}
