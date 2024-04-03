using Attendance_Time_tracking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Time_tracking_System.Data
{
    public class AttendanceSysDbContext : DbContext
    {
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<TrackSchedule> TrackSchedules { get; set; }
        public virtual DbSet<TrackSupervisor> TrackSupervisors { get; set; }
        public virtual DbSet<StudentTrackIntake> StudentTrackIntakes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentTrackIntake>().HasKey(x => new {x.StudentID, x.TrackID});
            modelBuilder.Entity<TrackSupervisor>().HasKey(x => new { x.InstructorID, x.IntakeID });
            modelBuilder.Entity<TrackSchedule>().HasKey(x => new {x.ScheduleID, x.IntakeID});
            modelBuilder.Entity<User>(a =>
            {
                a.UseTpcMappingStrategy();
            });
        }


    }
    
  


}
   

