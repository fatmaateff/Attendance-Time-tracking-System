using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly AttendanceSysDbContext db;
        public BranchRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
        public List<Branch> GetAll()
        {
            return db.Branchs.ToList();
        }

    }
}
