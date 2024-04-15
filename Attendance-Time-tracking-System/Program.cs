using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace Attendance_Time_tracking_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IStudentRepository,StudentRepository>();
            //builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //builder.Services.AddScoped<IBranchRepository, BranchRepository>();
            //builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            //builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITrackRepository, TrackRepository>();
            //builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
            //builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
            //builder.Services.AddTransient<IStudentRepository, StudentRepository>();
            //builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
            //builder.Services.AddScoped<ISupervisorRepository, SupervisorRepository>();

            builder.Services.AddDbContext<AttendanceSysDbContext>();
            //for excel sheeet
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
