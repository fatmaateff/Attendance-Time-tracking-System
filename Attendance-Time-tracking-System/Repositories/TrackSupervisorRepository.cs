using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Time_tracking_System.Repositories
{
    public class TrackSupervisorRepository : ITrackSupervisorRepository
    {
        private readonly AttendanceSysDbContext db;

        public TrackSupervisorRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
        public List<TrackSupervisor> GetAll()
        {
            return db.TrackSupervisors.Include(ts => ts.Track).Include(ts=> ts.Instructor).Include(ts=> ts.Branch).Include(ts => ts.Intake).ToList();
        }
        public bool Exists(int trackId, int supervisorId, int intakeId, int branchId)
        {
            return db.TrackSupervisors
                .Any(ts => ts.TrackID == trackId &&
                           ts.InstructorID == supervisorId &&
                           ts.IntakeID == intakeId &&
                           ts.BranchID == branchId);
        }
        public bool exists(int trackId, int intakeId, int branchId)
        {
            return db.TrackSupervisors.Any(ts => ts.TrackID == trackId && ts.IntakeID == intakeId && ts.BranchID == branchId);

        }
        public void Add(TrackSupervisor trackSupervisor)
        {
            db.TrackSupervisors.Add(trackSupervisor);
            db.SaveChanges();
        }
        public void Update(TrackSupervisor trackSupervisor)
        {
            db.TrackSupervisors.Update(trackSupervisor);
        }
        public void Delete(int intakeId, int instructorId)
        {
            var trackSupervisor = db.TrackSupervisors.FirstOrDefault(i=> i.IntakeID == intakeId &&  i.InstructorID == instructorId) ;
            if (trackSupervisor != null)
            {
                db.TrackSupervisors.Remove(trackSupervisor);
                db.SaveChanges();
            }else
            {
                throw new InvalidOperationException("Track Supervisor not found");
            }
        }
    }
}
