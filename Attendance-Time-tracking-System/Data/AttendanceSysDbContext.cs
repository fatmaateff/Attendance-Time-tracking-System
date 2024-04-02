using Attendance_Time_tracking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Time_tracking_System.Data
{
    public class AttendanceSysDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

    }
   
}
