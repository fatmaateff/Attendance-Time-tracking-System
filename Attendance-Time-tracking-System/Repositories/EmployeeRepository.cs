using Attendance_Time_tracking_System.Data;

namespace Attendance_Time_tracking_System.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AttendanceSysDbContext db;
        public EmployeeRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
        //methods to implement
    }
}
