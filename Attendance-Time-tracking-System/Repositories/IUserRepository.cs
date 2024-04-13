using Attendance_Time_tracking_System.Enums;

namespace Attendance_Time_tracking_System.Repositories
{
    public interface IUserRepository
    {
        //names of methods to implement

        public User GetUserById(int id);

        public IEnumerable<User> GetEmployees(int branchId);

        IEnumerable<User> GetStudents(int branchId);

    }
}
