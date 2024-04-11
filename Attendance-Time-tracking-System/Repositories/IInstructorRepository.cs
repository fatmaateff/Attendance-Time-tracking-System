using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public interface IInstructorRepository
    {
      List<Instructor> GetAll();
      void Add(Instructor instructor);
        Instructor GetById(int id);
        void Update (Instructor instructor);
        void Delete(int id);

    }
}
