using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;


namespace Attendance_Time_tracking_System.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly AttendanceSysDbContext _db;
        public BranchRepository(AttendanceSysDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Student> GetBranchStundents(int branchId, int intakeId, int? trackId = null)
        {
            IEnumerable<Student> stundets;

            if(trackId is null)
            {
                stundets = from student in _db.Students
                           join item in _db.StudentTrackIntakes
                           on student.Id equals item.StudentID
                           where student.BranchId == branchId && item.IntakeID == intakeId
                           select student;
            }
            else
            {
                stundets = from student in _db.Students
                           join item in _db.StudentTrackIntakes
                           on student.Id equals item.StudentID
                           where student.BranchId == branchId && item.IntakeID == intakeId && item.TrackID == trackId
                           select student;
            }

            return stundets;
        }

        public IEnumerable<Track> GetTracksInBranch(int branchId, int? intakeId = null)
        {
            IEnumerable<Track> allTracks;

            if (intakeId is null)
            {
                allTracks = _db.TrackSupervisors.Where(item => item.BranchID == branchId)
                                                 .Include(item => item.Track)
                                                 .Select(item => item.Track);
            }
            else
            {
                allTracks = _db.TrackSupervisors.Where(item => item.BranchID == branchId && item.IntakeID == intakeId)
                                                .Include(item => item.Track)
                                                .Select(item => item.Track);
            }

            return allTracks;
        }
        public List<Branch> GetAll()
        {
            return db.Branchs.ToList();
        }

    }
}
