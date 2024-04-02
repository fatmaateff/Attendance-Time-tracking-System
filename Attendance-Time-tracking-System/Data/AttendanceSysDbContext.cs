using Attendance_Time_tracking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Time_tracking_System.Data
{
    public class AttendanceSysDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(a =>
            {
                a.UseTpcMappingStrategy();
            });
        }
    }
    
  


}
   

