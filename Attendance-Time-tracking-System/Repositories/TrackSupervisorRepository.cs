using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public class TrackSupervisorRepository : ITrackSupervisorRepository
    {
        private readonly AttendanceSysDbContext db;

        public TrackSupervisorRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
        public bool exists(int trackId, int supervisorId, int intakeId, int branchId)
        {
            return db.TrackSupervisors
                .Any(ts => ts.TrackID == trackId &&
                           ts.InstructorID == supervisorId &&
                           ts.IntakeID == intakeId &&
                           ts.BranchID == branchId);
        }
        public void Add(TrackSupervisor trackSupervisor)
        {
            db.TrackSupervisors.Add(trackSupervisor);
            db.SaveChanges();
        }
    }
}
