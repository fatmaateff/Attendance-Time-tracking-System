using Attendance_Time_tracking_System.Data;

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
        //method to get attendance by id
        //method to add attendance
        //method to delete attendance

    }
    {
    }
}
