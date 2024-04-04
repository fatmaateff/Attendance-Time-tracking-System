using Attendance_Time_tracking_System.Data;

namespace Attendance_Time_tracking_System.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AttendanceSysDbContext db;
        public ScheduleRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
    }
}
