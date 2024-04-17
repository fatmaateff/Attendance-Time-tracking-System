using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AttendanceSysDbContext db;
        public EmployeeRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
        //methods to implement
        public List<Employee> GetAll()
        {
            return db.Employees.Where(e=> e.IsDeleted == false).ToList();
        }
        public Employee GetById(int id)
        {
            return db.Employees.FirstOrDefault(e=>e.Id == id);
        }
        public void Add(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }
        public void Update(Employee employee)
        {
            db.Employees.Update(employee);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var employee = GetById(id);
            employee.IsDeleted = true;
            db.SaveChanges();
        }
    }
}
