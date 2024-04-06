using Attendance_Time_tracking_System.Enums;

namespace Attendance_Time_tracking_System.ViewModels;

public class AttendanceIndexVM
{
    public bool IsStudent { get; set; }

    public IEnumerable<Student> Students { get; set; }

    public IEnumerable<User> Users { get; set; }

}
