using Attendance_Time_tracking_System.ViewModels;

namespace Attendance_Time_tracking_System.Repositories;

public interface IAttendanceRepository
{


    /// <summary>
    /// inserts the attendance list (containing id for each user and arrival date) to DB
    /// </summary>
    /// <param name="attendanceList">List of Users Attendance(including id + arrival time for each user)</param>
    /// <returns>true if insertion done successfully ,others returns false.</returns>

    bool tryTakeAttendance(IEnumerable<TakeAttendanceVW> attendanceList);

  

}