using Attendance_Time_tracking_System.Data;

namespace Attendance_Time_tracking_System.Repositories
{
    public class IntakeRepository : IIntakeRepository
    {
        AttendanceSysDbContext _db;
        public IntakeRepository(AttendanceSysDbContext db)
        {
            _db = db;
        }
    }
}
