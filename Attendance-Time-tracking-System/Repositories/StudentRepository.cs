using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Time_tracking_System.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AttendanceSysDbContext db;
        public StudentRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
        
        public List<StudentTrackIntake> getall()
        {
            var model = db.StudentTrackIntakes.Where(a=>a.Student.IsDeleted==false).ToList();
          
            return model;

        }
        public void delete(int id)
        {
            var model=db.Students.FirstOrDefault(a=>a.Id==id);
            var permession=db.permissions.FirstOrDefault(a=>a.StdId==id);
            if (permession != null)
            {
                db.Remove(permession);
            }
            model.IsDeleted = true;
            db.SaveChanges();

        }
    }
}
