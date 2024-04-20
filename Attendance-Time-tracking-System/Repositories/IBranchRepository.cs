using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public interface IBranchRepository
    {
        List<Branch> GetAll();
        List<Branch> GetBranchesByProgramId(int programId);
    }
}