﻿using Attendance_Time_tracking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Time_tracking_System.Data
{
    public class AttendanceSysDbContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ProgramType> Programs { get; set; }
        public DbSet<TrackSchedule> TrackSchedules { get; set; }
        public DbSet<TrackSupervisor> TrackSupervisors { get; set; }
        public DbSet<StudentTrackIntake> StudentTrackIntakes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Permission> permissions { get; set; }

        public DbSet<Track> Tracks { get; set; }
        public DbSet<Intake> Intakes { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public object GetById { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=tcp:fahmy-server.database.windows.net,1433;Initial Catalog=ITIAttendanceSystem;Persist Security Info=False;User ID=ahmed;Password=Uchiha123goat*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentTrackIntake>().HasKey(x => new {x.StudentID, x.TrackID});
            modelBuilder.Entity<TrackSupervisor>().HasKey(x => new { x.InstructorID, x.IntakeID });
            modelBuilder.Entity<TrackSchedule>().HasKey(x => new {x.ScheduleID, x.IntakeID});
            modelBuilder.Entity<User>(a =>
            {
                a.UseTptMappingStrategy();
            });

            modelBuilder.Entity<Permission>().HasKey(p => new { p.StdId, p.Date });

        }
    }
    
  


}
   

