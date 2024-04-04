using Attendance_Time_tracking_System.Data;

namespace Attendance_Time_tracking_System.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AttendanceSysDbContext db;
        public StudentRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
        //methods to implement
    }
}
