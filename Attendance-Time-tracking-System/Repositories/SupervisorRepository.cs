using Attendance_Time_tracking_System.Data;

namespace Attendance_Time_tracking_System.Repositories
{
    public class SupervisorRepository : ISupervisorRepository
    {
        private readonly AttendanceSysDbContext db;
        public SupervisorRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
    }
}
