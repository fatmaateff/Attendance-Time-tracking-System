﻿using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

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
            var model = db.StudentTrackIntakes.Where(a => a.Student.IsDeleted == false).ToList();

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
    }
}

