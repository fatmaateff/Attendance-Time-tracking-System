using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Time_tracking_System.Controllers
{
    public class UserController : Controller
    {
        AttendanceSysDbContext context = new AttendanceSysDbContext();

        public IActionResult Profile(int id)
        {
            User userModel = context.Users.Include(u => u.Branch).FirstOrDefault(e => e.Id == id);

            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }
    }
}
