using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly AttendanceSysDbContext db;
        public ProgramRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
        public List<ProgramType> GetAll()
        {
            return db.Programs.ToList();
        }
    }
}
