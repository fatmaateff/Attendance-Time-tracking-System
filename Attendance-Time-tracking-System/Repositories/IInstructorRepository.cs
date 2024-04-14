using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public interface IInstructorRepository
    {
       public List<Instructor> GetAll();
       public Instructor Add(Instructor instructor);
    }
}
