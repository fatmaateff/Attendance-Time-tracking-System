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
        public List<Branch> GetBranchesByProgramId(int programId)
        {
            DateTime now = DateTime.Now;
            DateOnly today = new DateOnly(now.Year,now.Month,now.Day);
            int intakeId = db.Intakes.OrderBy(x => x.StartDate)
                .FirstOrDefault(x => (today >= x.StartDate && today <= x.EndDate) || today < x.StartDate).Id;

            return db.TrackSupervisors
                .Where(x => x.Track.ProgramID == programId && x.IntakeID == intakeId)
                .Select(x => x.Branch)
                .Distinct()
                .ToList();
        }
    }
}
