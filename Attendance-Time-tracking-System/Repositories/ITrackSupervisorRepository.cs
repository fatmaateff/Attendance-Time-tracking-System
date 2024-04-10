using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public interface ITrackSupervisorRepository
    {
        //here i want to assign supervisor for a track
        bool exists(int trackId, int supervisorId);
        void Add(TrackSupervisor trackSupervisor);
    }
}
