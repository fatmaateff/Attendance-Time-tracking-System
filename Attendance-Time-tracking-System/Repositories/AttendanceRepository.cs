namespace Attendance_Time_tracking_System.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly AttendanceSysDbContext _db;
    public AttendanceRepository(AttendanceSysDbContext db)
    {
        _db = db;
    }

    public bool tryTakeAttendance(IEnumerable<TakeAttendanceVW> attendanceList)
    {
        try
        {
            foreach (TakeAttendanceVW userAttendance in attendanceList)
            {

                _db.Attendances.Add(new Attendance
                {
                    UserId = userAttendance.Id,
                    Date = userAttendance.ArrivalDate,
                    TimeIn = userAttendance.ArrivalTime,
                    TimeOut = userAttendance.DepatureTime,
                });
            }

            _db.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    
    
    //method to get all attendances
    //method to get attendance by id
    //method to add attendance
    //method to delete attendance





    
}


