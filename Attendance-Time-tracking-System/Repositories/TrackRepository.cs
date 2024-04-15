using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly AttendanceSysDbContext db;
         public TrackRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
        public List<Track> getalltrackes()
        {
            return db.Tracks.ToList();
        }
    }
}
