using Attendance_Time_tracking_System.Enums;

namespace Attendance_Time_tracking_System.Repositories
{
    public interface IUserRepository
    {
        //names of methods to implement

        public User GetUserById(int id);

        public IEnumerable<User> GetEmployees(int branchId);

        IEnumerable<User> GetStudents(int branchId);


        /// <summary>
        /// gets track students with their attendace in a specific date
        /// </summary>
        /// <param name="trackId">track id</param>
        /// <param name="date">attedance date</param>
        /// <returns>returns collection of track stundets with their attendance in a specific date</returns>
        IEnumerable<User> GetStudentsWithAttedance(int branchId, DateOnly date);


        /// <summary>
        /// gets track employees with their attendace in a specific date
        /// </summary>
        /// <param name="trackId">track id</param>
        /// <param name="date">attedance date</param>
        /// <returns>returns collection of track employees with their attendance in a specific date</returns>
        IEnumerable<User> GetEmployeesWithAttedance(int branchId, DateOnly date);

    }

}
