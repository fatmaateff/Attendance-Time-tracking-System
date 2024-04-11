using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public class IntakeRepository : IIntakeRepository
    {
        AttendanceSysDbContext db;
        public IntakeRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
        public List<Intake> GetAll()
        {
            return db.Intakes.ToList();
        }
    }
}
