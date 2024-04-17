using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Enums;
using System.Data;

namespace Attendance_Time_tracking_System.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AttendanceSysDbContext _db;
        public UserRepository(AttendanceSysDbContext db)
        {
            _db = db;
        }
        
        public IEnumerable<User> GetStudents(int branchId)
        {
            IEnumerable<User> users = _db.Users.Where(user => user.BranchId == branchId && user.Role.Equals(RoleType.Student));
                                               
            return users;
        }

        public IEnumerable<User> GetEmployees(int branchId)
        {
            IEnumerable<User> users = _db.Users.Where(user => user.BranchId == branchId && !user.Role.Equals(RoleType.Student));
            return users;
        }
        public User GetUserById(int id)
        {
            User user = _db.Users.SingleOrDefault(user => user.Id == id);
            return user;
        }

        public IEnumerable<User> GetStudentsWithAttedance(int branchId, DateOnly date)
        {
            IEnumerable<User> users = _db.Users.Where(user => user.BranchId == branchId && user.Role.Equals(RoleType.Student))
                                               .Include(user=> user.Attendances.Where(a => a.Date ==date));

            return users;
        }

        public IEnumerable<User> GetEmployeesWithAttedance(int branchId, DateOnly date)
        {
            IEnumerable<User> users = _db.Users.Where(user => user.BranchId == branchId && !user.Role.Equals(RoleType.Student))
                                               .Include(user=> user.Attendances.Where(a => a.Date ==date));
            return users;
        }
        //methods to implement
    }
}
