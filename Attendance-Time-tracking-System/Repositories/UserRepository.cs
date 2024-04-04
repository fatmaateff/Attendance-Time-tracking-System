using Attendance_Time_tracking_System.Data;

namespace Attendance_Time_tracking_System.Repositories
{
    public class UserRepository : IUserRepository
    {
        AttendanceSysDbContext db;
        public UserRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
        //methods to implement
    }
}
