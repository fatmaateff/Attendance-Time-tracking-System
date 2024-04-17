using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;

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
            db = _db;
        }
        //method to get all attendances
        public List<Attendance> GetAttendanceById(int id)
        {
            List<Attendance> attendances = db.Attendances.Where(a => a.UserId == id).ToList();
            return attendances;
        }
        //method to add attendance
        //method to delete attendance
        
    }
    }


