using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public interface IStudentRepository
    {
        //names of methods to implement

        public List<StudentTrackIntake> getall(int id);
        void RegisterStudent(AddStudentViewModel student);
        public void delete(int id);
        public void add(AddStudentViewModel std);
        public void ImportDataFromExcel(string filePath);
        public User getUserById(int id);
        public void addpermission(Permission pre, int id);
        public bool detectpermissioninsamedate(Permission pre, int id);
        public int numofpermissions(int id);
        public List<Permission> allpermissions(int id);
        public void deletepermission(DateOnly dateTime);



    }
}
