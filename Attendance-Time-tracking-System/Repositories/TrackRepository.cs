using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Time_tracking_System.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly AttendanceSysDbContext db;
         public TrackRepository(AttendanceSysDbContext _db)
         {
            db = _db;
         }
        public List<Track> GetAll()
        {
            return db.Tracks.Where(t=> t.IsDeleted == false).ToList();
        }
        public void Add(Track track)
        {
            db.Tracks.Add(track);
            db.SaveChanges();
        }
        public Track GetById(int id)
        {
            return db.Tracks.FirstOrDefault(I => I.Id == id);
        }
        public void Update(Track track)
        {
            db.Tracks.Update(track);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var track = GetById(id);
            track.IsDeleted = true;
            db.SaveChanges();
        }


    }
}
