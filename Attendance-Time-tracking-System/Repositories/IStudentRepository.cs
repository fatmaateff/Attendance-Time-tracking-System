using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public interface IStudentRepository
    {
        //names of methods to implement

        public List<StudentTrackIntake> getall();
        public void delete(int id);

    }
}
