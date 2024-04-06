using Attendance_Time_tracking_System.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Attendance_Time_tracking_System.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly AttendanceSysDbContext _db;
        public TrackRepository(AttendanceSysDbContext db)
        {
            _db = db;
        }

    }
}
