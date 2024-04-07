using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Enums;
using System.Data;

namespace Attendance_Time_tracking_System.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AttendanceSysDbContext db;
        public UserRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }

        public IEnumerable<User> GetInstructor(int branchId)
        {
            IEnumerable<User> instructors = db.Users.Where(user => user.Role =="Instructor");

            return instructors;
        }
        public IEnumerable<User> GetEmployees(int branchId)
        {
            IEnumerable<User> employees = db.Users.Where(user => user.Role == RoleType.StudentAffair.ToString() || user.Role == RoleType.Employee.ToString());


            return employees;
        }


        //methods to implement
    }
}
