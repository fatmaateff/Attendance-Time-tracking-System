using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public interface ISupervisorRepository
    {
        public List<StudentTrackIntake> getstudentid(int id);
        public TrackSupervisor finduser(int id);
        public List<Permission> getpermissions(List<StudentTrackIntake> std);
        public void accept(DateOnly date);
        public void refuse(DateOnly date);

    }
}