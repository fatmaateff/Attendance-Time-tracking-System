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
        public void Add(Instructor instructor)
        {
            db.Instructors.Add(instructor);
            db.SaveChanges();
        }
        public Instructor GetById(int id)
        {
            return db.Instructors.Where(I=> I.IsDeleted == false ).FirstOrDefault(I => I.Id == id);
        }

        public void Update(Instructor instructor)
        {

            db.Instructors.Update(instructor);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var instructor = GetById(id);
            instructor.IsDeleted = true;
            db.SaveChanges();
        }
        // InstructorRepository.cs
        public void UpdateRoleToSupervisor(int instructorId)
        {
            var instructor = db.Instructors.FirstOrDefault(i => i.Id == instructorId);
            if (instructor != null)
            {
                instructor.Role = "Supervisor";
                db.SaveChanges();
            }
        }


    }
}
