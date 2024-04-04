using Attendance_Time_tracking_System.Data;

namespace Attendance_Time_tracking_System.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        AttendanceSysDbContext db;
        public TrackRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }

    }
}
