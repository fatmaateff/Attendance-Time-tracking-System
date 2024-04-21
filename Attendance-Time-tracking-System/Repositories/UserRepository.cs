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
            IEnumerable<User> users = _db.Users.Where(user => user.BranchId == branchId && user.Role == "Student")
                                               .Include(user=> user.Attendances.Where(a => a.Date ==date));

            return users;
        }

        public IEnumerable<User> GetEmployeesWithAttedance(int branchId, DateOnly date)
        {
            IEnumerable<User> users = _db.Users.Where(user => user.BranchId == branchId && user.Role != "Student")
                                               .Include(user=> user.Attendances.Where(a => a.Date ==date));
            return users;
        }

        public string getUsernameById (int id)
        {
            return _db.Users.FirstOrDefault(u => u.Id == id).Name;
        }
        //methods to implement
        public List<AddStudentViewModel> GetPendingStudentRequests(int branchId)
        {
            List<AddStudentViewModel> addStudentViewModels = new List<AddStudentViewModel>();
            List<User> pendingStudents = _db.Users.Where(x => x.IsDeleted==false && x.Status == StudentStatus.Pending && x.BranchId == branchId).ToList();
            foreach (User user in pendingStudents)
            {
                AddStudentViewModel addStudentViewModel = new AddStudentViewModel();
                addStudentViewModel.student.Id = user.Id;
                addStudentViewModel.student.Name = user.Name;
                addStudentViewModel.student.Email = user.Email;
                addStudentViewModel.student.Mobile = user.Mobile;

                Student student = _db.Students.FirstOrDefault(x => x.Id == user.Id);
                addStudentViewModel.student.University = student.University;
                addStudentViewModel.student.Faculty = student.Faculty;
                addStudentViewModel.student.Specialization = student.Specialization;
                addStudentViewModel.student.GradYear = student.GradYear;

                DateTime now = DateTime.Now;
                DateOnly today = new DateOnly(now.Year, now.Month, now.Day);
                int intakeId = _db.Intakes.OrderBy(x => x.StartDate)
                    .FirstOrDefault(x => (today >= x.StartDate && today <= x.EndDate) || today < x.StartDate).Id;
                StudentTrackIntake sti = _db.StudentTrackIntakes.FirstOrDefault(x => x.IntakeID == intakeId && x.StudentID == user.Id);
                addStudentViewModel.StudentTrackIntake.Track = sti.Track;
                addStudentViewModels.Add(addStudentViewModel);
            }
            return addStudentViewModels;
        }
        public void RespondToStudentRequest(int studentId, int res)
        {
            var user = _db.Users.FirstOrDefault(x => x.Id == studentId);
            if(user != null)
            {
                if(res==1)
                    user.Status = StudentStatus.Accepted;
                else
                    user.Status = StudentStatus.Declined;
            }
            _db.SaveChanges();
        }
    }
}
