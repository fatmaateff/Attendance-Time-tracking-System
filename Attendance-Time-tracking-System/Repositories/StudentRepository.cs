using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Security.Claims;

namespace Attendance_Time_tracking_System.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AttendanceSysDbContext db;
        public StudentRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }

        public List<StudentTrackIntake> getall(int id)
        {
            
            var userBranchId=db.Users.FirstOrDefault(a=>a.Id==id).BranchId;
            var model = db.StudentTrackIntakes.Where(a => a.Student.IsDeleted == false &&a.Student.BranchId== userBranchId).ToList();

            return model;

        }
        public void delete(int id)
        {
            var model = db.Students.FirstOrDefault(a => a.Id == id);
            var permession = db.permissions.FirstOrDefault(a => a.StdId == id);
            if (permession != null)
            {
                db.Remove(permession);
            }
            model.IsDeleted = true;
            db.SaveChanges();

        }
        public void add(AddStudent std)
        {

            std.student.Role = "Student";

            std.student.BranchId = 1;
            std.student.IsDeleted = false;

            db.Students.Add(std.student);
            db.SaveChanges() ;
            std.StudentTrackIntake.StudentID=std.student.Id;
            std.StudentTrackIntake.IntakeID = 1;
            db.StudentTrackIntakes.Add(std.StudentTrackIntake);

            db.SaveChanges();



        }
        public User getUserById (int id)
        {
            return db.Users.FirstOrDefault(a => a.Id == id);
        }
        public void ImportDataFromExcel(string filePath)
        {
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                int rowCount = worksheet.Dimension.End.Row;
                int columnCount = worksheet.Dimension.Columns;

                for (int row = 2; row <= rowCount; row++)
                {
                    AddStudent entity = new AddStudent();
                    StudentTrackIntake std = new StudentTrackIntake();
                    entity.student.Name = worksheet.Cells[row, 1].Value.ToString() ?? "";
                    entity.student.Email = worksheet.Cells[row, 2].Value.ToString() ?? "";
                    entity.student.Password = worksheet.Cells[row, 3].Value.ToString() ?? "";
                    entity.student.Role = "Student";
                    entity.student.Mobile = int.Parse(worksheet.Cells[row, 5].Value.ToString() ?? "");
                    entity.student.BranchId = int.Parse(worksheet.Cells[row, 6].Value.ToString() ?? "");
                    entity.student.IsDeleted = false;
                    entity.student.University = worksheet.Cells[row, 8].Value.ToString() ?? "";
                    entity.student.Faculty = worksheet.Cells[row, 9].Value.ToString() ?? "";
                    entity.student.Specialization = worksheet.Cells[row, 10].Value.ToString() ?? "";
                    entity.student.GradYear = int.Parse(worksheet.Cells[row, 11].Value.ToString() ?? "");
                    db.Students.Add(entity.student);
                    db.SaveChanges();
                    entity.StudentTrackIntake.StudentID = entity.student.Id;
                    entity.StudentTrackIntake.IntakeID = 1;
                    entity.StudentTrackIntake.TrackID = int.Parse(worksheet.Cells[row, 12].Value.ToString() ?? "");
                }
                db.SaveChanges();
            }
        }
        public void addpermission(Permission pre, int id)
        {
            var userId = db.Users.FirstOrDefault(a => a.Id == id).Id;
            pre.StdId = userId;
            pre.Status = Enums.PermissionStatus.pending;
            db.permissions.Add(pre);
            db.SaveChanges() ;
        }
        public bool detectpermissioninsamedate(Permission pre, int id)
        {
            var model=db.permissions.FirstOrDefault(a=>a.StdId == id &&a.Date==pre.Date);
            if(model==null) return false;
            else return true;
        }
        public int numofpermissions(int id)
        {
            var model=db.permissions.Where(a=>a.StdId==id).ToList();
            int i = 0;
            foreach(var permission in model)
            {
                i++;
            }
            return i;
        }
        public List<Permission> allpermissions(int id)
        {
            var model = db.permissions.Where(a => a.StdId == id).ToList();
            return model;
        }
        public void deletepermission(DateOnly dateTime)
        {
            if(dateTime >= DateOnly.FromDateTime(DateTime.UtcNow.Date))
            {
                var model = db.permissions.FirstOrDefault(a => a.Date == dateTime);
                db.permissions.Remove(model);
                db.SaveChanges();

            }
          
        }
    }
}

