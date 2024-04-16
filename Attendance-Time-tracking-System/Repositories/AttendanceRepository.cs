using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AttendanceSysDbContext db;
        public AttendanceRepository(AttendanceSysDbContext _db)
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

