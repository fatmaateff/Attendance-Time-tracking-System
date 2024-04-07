using Attendance_Time_tracking_System.Enums;

namespace Attendance_Time_tracking_System.Repositories
{
    public interface IUserRepository
    {
        //names of methods to implement
        public IEnumerable<User> GetInstructor(int branchId);

        public IEnumerable<User> GetEmployees(int branchId);

    }
}
