using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public interface IAttendanceRepository
    {
        List<Attendance> GetAttendanceById(int id);
    }
}