using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public interface IAttendanceRepository
    {
        List<Attendance> GetAttendanceById(int id);
        List<Attendance> GetLateAttendanceById(int id);
        List<Attendance> GetAbsentAttendanceById(int id);
        List<Attendance> GetAttendentAttendanceById(int id);
    }
}