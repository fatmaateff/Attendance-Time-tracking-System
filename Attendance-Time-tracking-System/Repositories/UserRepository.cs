using Attendance_Time_tracking_System.Data;

namespace Attendance_Time_tracking_System.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AttendanceSysDbContext db;
        public UserRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }

        public string getUsernameById (int id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id).Name;
        }
        //methods to implement
    }
}
