using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public interface IStudentRepository
    {
        //names of methods to implement

        public List<StudentTrackIntake> getall(int id);
        public void delete(int id);
        public void add(AddStudent std);
        public void ImportDataFromExcel(string filePath);
        public User getUserById(int id);

    }
}
