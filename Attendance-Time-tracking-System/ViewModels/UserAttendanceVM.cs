namespace Attendance_Time_tracking_System.ViewModels;

public class UserAttendanceVM
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly? TimeIn { get; set; }

    public TimeOnly? TimeOut { get; set; }

    public AttendanceStatus Status { get; set; }
}
