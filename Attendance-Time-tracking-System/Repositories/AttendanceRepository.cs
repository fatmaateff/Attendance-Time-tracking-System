using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Enums;
using Attendance_Time_tracking_System.Models;
using Microsoft.CodeAnalysis.Operations;
using NuGet.DependencyResolver;

namespace Attendance_Time_tracking_System.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly AttendanceSysDbContext _db;
    public AttendanceRepository(AttendanceSysDbContext db)
    {
        _db = db;
    }

    public bool TryMarkUserAttendance(Attendance attendance)
    {
        try
        {
            Attendance existing_Attedance = _db.Attendances.FirstOrDefault(a => a.UserId == attendance.UserId && a.Date == attendance.Date);
            existing_Attedance.TimeIn = attendance.TimeIn;
            existing_Attedance.Status = attendance.Status;
                   
            _db.SaveChanges();
       
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool TryResetAttendance(int userId ,DateOnly date)
    {
        try
        {
            Attendance existing_Attedance = _db.Attendances.FirstOrDefault(a => a.UserId == userId && a.Date == date);
            existing_Attedance.TimeIn = null;
            existing_Attedance.TimeOut = null;
            existing_Attedance.Status = AttendanceStatus.Absent;

            _db.SaveChanges();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool TryMarkDeparture(Attendance attendance)
    {
        try
        {
            Attendance existingAttendance = _db.Attendances.FirstOrDefault(a => a.UserId == attendance.UserId && a.Date == attendance.Date);
            if (attendance == null)
                return false;

            existingAttendance.TimeOut = attendance.TimeOut;

            _db.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
        //method to get all attendances
        public List<Attendance> GetLateAttendanceById(int id)
        {
            List<Attendance> attendances = _db.Attendances.Where(a => a.UserId == id && a.Status == AttendanceStatus.Late).ToList();
            return attendances;
        }
        public List<Attendance> GetAbsentAttendanceById(int id)
        {
            List<Attendance> attendances = _db.Attendances.Where(a => a.UserId == id && a.Status == AttendanceStatus.Absent).ToList();
            return attendances;
        }
        public List<Attendance> GetAttendentAttendanceById(int id)
        {
            List<Attendance> attendances = _db.Attendances.Where(a => a.UserId == id && a.Status == AttendanceStatus.Attendant).ToList();
            return attendances;
        }

        public List<Attendance> GetAttendanceById(int id)
        {
            List<Attendance> attendances = _db.Attendances.Where(a => a.UserId == id).ToList();
            return attendances;
        }

        public Attendance GetUserAttendance(int userId, DateOnly date)
        {
            Attendance attendance = _db.Attendances.Include(attendance => attendance.User)
                                .FirstOrDefault(attendance => attendance.UserId == userId && attendance.Date == date);
                      


            return attendance;
        }

        public bool InitializeTrackAttendanceToday(int trackId, int intakeId, int branchId)
        {
            try
            {
                IEnumerable<Attendance> attendances = from student in _db.StudentTrackIntakes
                                                      join user in _db.Users on student.StudentID equals user.Id
                                                      where student.IntakeID == intakeId
                                                            && student.TrackID == trackId
                                                            && user.BranchId == branchId
                                                      select new Attendance()
                                                      {
                                                          UserId = student.StudentID,
                                                          Date = DateOnly.FromDateTime(DateTime.Now),
                                                          Status = AttendanceStatus.Absent
                                                      };
                _db.Attendances.AddRange(attendances);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool InitializeEmployeesAttendanceToday(int branchId)
        {
            try
            {
                IEnumerable<Attendance> attendances = from user in _db.Users
                                                      where user.BranchId == branchId
                                                      select new Attendance()
                                                      {
                                                          UserId = user.Id,
                                                          Date = DateOnly.FromDateTime(DateTime.Now),
                                                          Status = AttendanceStatus.Absent
                                                      };

                _db.Attendances.AddRange(attendances);
                _db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsStudentsAttendanceInitialized(int trackId, int intakeId, int branchId)
        {
            List<User> employeesAttendance = (from user in _db.Users
                                                    join StudentTrackIntake in _db.StudentTrackIntakes on user.Id equals StudentTrackIntake.StudentID
                                                    join attendance in _db.Attendances on user.Id equals attendance.UserId
                                                    where user.BranchId == branchId
                                                                && attendance.Date == DateOnly.FromDateTime(DateTime.Now)
                                                                && user.Role == "Student"
                                                    select user).ToList();

            return employeesAttendance.Any();
        }

        public bool IsEmployeesAttendanceInitialized(int branchId)
        {
            IEnumerable<User> employeesAttendance = from user in _db.Users
                                                    join attendance in _db.Attendances on user.Id equals attendance.UserId
                                                    where user.BranchId == branchId
                                                                && attendance.Date == DateOnly.FromDateTime(DateTime.Now)
                                                                && user.Role != "Student"
                                                    select user;

            return employeesAttendance.Any();


        }

        public IEnumerable<UserAttendanceVM> GetTrackAttendance(int trackId, int branchId ,int intakeId ,DateOnly date)
        {
            IEnumerable<UserAttendanceVM> userAttendanceCollection ;

            userAttendanceCollection = from student in _db.Students.Where(std => std.BranchId == branchId)
                                       join track in _db.StudentTrackIntakes on student.Id equals track.StudentID
                                       join attendacne in _db.Attendances on student.Id equals attendacne.UserId
                                       where track.TrackID == trackId
                                            && track.IntakeID == intakeId
                                            && attendacne.Date == date
                                       select new UserAttendanceVM()
                                       {
                                           Id = student.Id,
                                           Name = student.Name,
                                           TimeIn = attendacne.TimeIn,
                                           TimeOut = attendacne.TimeOut,
                                           Date = attendacne.Date,
                                           Status = attendacne.Status
                                       };

            return userAttendanceCollection;
        }

        public bool TryAlterUserAttendance(Attendance attendance)
        {
            try
            {
                Attendance existingAttendance = GetUserAttendance(attendance.UserId, attendance.Date);

                existingAttendance.Status = attendance.Status;

                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
}


