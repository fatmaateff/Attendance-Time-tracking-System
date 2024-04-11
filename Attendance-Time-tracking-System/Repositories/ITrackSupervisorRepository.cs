using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public interface ITrackSupervisorRepository
    {
         List<TrackSupervisor> GetAll();

        //here i want to assign supervisor for a track
        bool exists(int trackId, int intakeId, int branchId);

        void Add(TrackSupervisor trackSupervisor);
        bool Exists(int trackId, int instructorId, int intakeId, int branchId);
    }
}
