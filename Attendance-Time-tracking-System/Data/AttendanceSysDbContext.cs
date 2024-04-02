using Microsoft.EntityFrameworkCore;
using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Data
{
    public class AttendanceSysDbContext : DbContext
    {
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<TrackSchedule> TrackSchedules { get; set; }
        public virtual DbSet<TrackSupervisor> TrackSupervisors { get; set; }
        public virtual DbSet<StudentTrackIntake> StudentTrackIntakes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentTrackIntake>().HasKey(x => new {x.StudentID, x.TrackID});
            modelBuilder.Entity<TrackSupervisor>().HasKey(x => new { x.InstructorID, x.IntakeID });
            modelBuilder.Entity<TrackSchedule>().HasKey(x => new {x.ScheduleID, x.IntakeID});
        }
    }
   
}
