using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public interface ITrackRepository
    {
        List <Track> GetAll();
        void Add(Track track);
        Track GetById(int id);
        void Update (Track track);
        void Delete(int id);
    }
}