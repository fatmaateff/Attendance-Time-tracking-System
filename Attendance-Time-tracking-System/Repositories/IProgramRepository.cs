using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public interface IProgramRepository
    {
        List<ProgramType> GetAll();
    }
}