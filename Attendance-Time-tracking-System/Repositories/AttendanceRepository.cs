
namespace Attendance_Time_tracking_System.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly AttendanceSysDbContext _db;
    public AttendanceRepository(AttendanceSysDbContext db)
    {
        _db = db;
    }

    public bool TryInsertUserAttendance(Attendance attendance)
    {
        try
        {
            bool alreadymarked = GetUserAttendance(attendance.UserId, attendance.Date) is not null;
            if(alreadymarked)
                return false;
           _db.Attendances.Add(attendance);
           _db.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool TryResetAttendance(int userId ,DateOnly date)
    {
        try
        {
            Attendance attendace = _db.Attendances.FirstOrDefault(attedance => attedance.Date == date && attedance.UserId == userId);

            if (attendace is null)
                return false;

            attendace.Status = AttendanceStatus.Absent;
            attendace.TimeOut = null;
            _db.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool TryMarkDeparture(int userId, DateOnly date ,TimeOnly timeOut)
    {
        try
        {
            Attendance attendance = _db.Attendances.FirstOrDefault(attendance => attendance.UserId == userId && attendance.Date == date);
            if (attendance == null)
                return false;

            attendance.TimeOut = timeOut;
            _db.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Attendance GetUserAttendance(int userId, DateOnly date)
    {
        Attendance attendance = _db.Attendances
                            .FirstOrDefault(attendance => attendance.UserId == userId && attendance.Date == date);


        return attendance;
    }

    //method to get all attendances
    //method to get attendance by id
    //method to add attendance
    //method to delete attendance






}


