using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public class SupervisorRepository : ISupervisorRepository
    {
        private readonly AttendanceSysDbContext db;
        public SupervisorRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
        public TrackSupervisor finduser(int id)
        {
            var model=db.TrackSupervisors.FirstOrDefault(x => x.InstructorID == id);
            return model;

        }
        public List<StudentTrackIntake> getstudentid(int id)
        {
         var model=   db.StudentTrackIntakes.Where(a=>a.TrackID == id).ToList();
            return model;
        }
        public List<Permission> getpermissions(List<StudentTrackIntake> std)
        {
            List<Permission> list = new List<Permission>();
            foreach (var s in std)
            {
                var model=db.permissions.Where(a=>a.Status==Enums.PermissionStatus.pending).FirstOrDefault(a=>a.StdId==s.StudentID);
                if (model != null)
                {
                    list.Add(model);
                }

            }
            return list;
        }
        public void accept(DateOnly date)
        {
            var mode =db.permissions.FirstOrDefault(a=>a.Date==date);
            mode.Status=Enums.PermissionStatus.Accepted;
            db.SaveChanges();
        }
        public void refuse(DateOnly date)
        {
            var mode = db.permissions.FirstOrDefault(a => a.Date == date);
            mode.Status = Enums.PermissionStatus.Refused;
            db.SaveChanges();
        }

    }
}
