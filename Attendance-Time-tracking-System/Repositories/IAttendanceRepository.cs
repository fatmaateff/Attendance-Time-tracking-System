using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories;

public interface IAttendanceRepository
{


    public List<Attendance> GetAttendanceById(int id);

    /// <summary>
    /// insert row for user attendance
    /// </summary>
    /// <param name="attendance">infoe about user attendance</param>
    /// <returns>returns true if row inserted successfully, otherwise false.</returns>
    public bool TryMarkUserAttendance(Attendance attendance);


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

    public bool TryMarkDeparture(Attendance attendance);

    /// <summary>
    /// gets user attendance in a specific date.
    /// </summary>
    /// <param name="userId">user Id</param>
    /// <param name="date">attendance date</param>
    /// <returns>returns user attendance in the given date</returns>
    public Attendance GetUserAttendance(int userId, DateOnly date);

    /// <summary>
    /// initialize attendance for all tracks have schedule today by default false.
    /// </summary>
    /// <returns>returns true if initialization successfully done ,others returns false.</returns>
    public bool InitializeTrackAttendanceToday(int trackId, int intakeId, int branchId);


    /// <summary>
    /// initialize attendance for all tracks have schedule today by default false.
    /// </summary>
    /// <returns>returns true if initialization successfully done ,others returns false.</returns>
    public bool InitializeEmployeesAttendanceToday(int branchId);


    /// <summary>
    /// checks if Students attendance is initialized today.
    /// </summary>
    /// <returns>true if initialized others false</returns>
    public bool IsStudentsAttendanceInitialized(int trackId, int intakeId ,int branchId);

    /// <summary>
    /// checks if the Employee attendance is initialized today.
    /// </summary>
    /// <returns>true if initialized others false</returns>
    public bool IsEmployeesAttendanceInitialized(int branchId);

    /// <summary>
    /// gets attendance track in a specific date.
    /// </summary>
    /// <param name="date"> date you wanna attendance in</param>
    /// <returns>returns a collection of users Attendacane</returns>
    public IEnumerable<UserAttendanceVM> GetTrackAttendance(int trackId, int branchId, int intakeId, DateOnly date);


    public bool TryAlterUserAttendance(Attendance attendance);
}