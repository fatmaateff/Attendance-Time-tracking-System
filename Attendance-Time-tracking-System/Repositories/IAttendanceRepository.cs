using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories;

public interface IAttendanceRepository
{

    /// <summary>
    /// insert row for user attendance
    /// </summary>
    /// <param name="attendance">infoe about user attendance</param>
    /// <returns>returns true if row inserted successfully, otherwise false.</returns>
    public bool TryInsertUserAttendance(Attendance attendance);

    /// <summary>
    /// reset attedance for a user to be false.
    /// </summary>
    /// <param name="date">date to reset attedance in</param>
    /// <returns>returns true if success ,others false</returns>
    public bool TryResetAttendance(int userId ,DateOnly date);


    /// <summary>
    /// mark departure for a user in a specific date and records departure time.
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <param name="date">Attedance Date</param>
    /// <param name="timeOut">Departure time</param>
    /// <returns>returns true if it's successfully recorded ,others false.</returns>

    public bool TryMarkDeparture(int userId, DateOnly date, TimeOnly timeOut);

    /// <summary>
    /// gets user attendance in a specific date.
    /// </summary>
    /// <param name="userId">user Id</param>
    /// <param name="date">attendance date</param>
    /// <returns>returns user attendance in the given date</returns>
    public Attendance GetUserAttendance(int userId, DateOnly date);
}