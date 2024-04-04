using Attendance_Time_tracking_System.Data;
using System.Security;

namespace Attendance_Time_tracking_System.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        AttendanceSysDbContext db;
        public PermissionRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
        //method to get all permissions
        //method to get permission by id
        //method to add permission
        //method to delete permission

    }
}
