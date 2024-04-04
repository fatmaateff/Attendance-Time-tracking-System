using Attendance_Time_tracking_System.Data;

namespace Attendance_Time_tracking_System.Repositories
{
    public class InstuctorRepository : IInstructorRepository
    {
        AttendanceSysDbContext db;
        public InstuctorRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
    }
}
