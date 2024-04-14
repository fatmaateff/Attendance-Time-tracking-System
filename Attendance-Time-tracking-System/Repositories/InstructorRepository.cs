using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        AttendanceSysDbContext db;
        public InstructorRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
        public List<Instructor> GetAll()
        {
               return db.Instructors.Where(I=> I.IsDeleted == false ).ToList();
        }
        public Instructor Add(Instructor instructor)
        {
            db.Instructors.Add(instructor);
            db.SaveChanges();
            return instructor;
        }
    }
}
