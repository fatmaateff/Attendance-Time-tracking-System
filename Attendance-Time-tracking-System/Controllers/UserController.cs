using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Attendance_Time_tracking_System.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        AttendanceSysDbContext context = new AttendanceSysDbContext();
        public IActionResult Profile()
        {
            int id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            User userModel = context.Users
                .Include(u => u.Branch)
                .FirstOrDefault(e => e.Id == id);

            if (userModel == null)
            {
                return NotFound();
            } 

            return View(userModel);
        }

        public IActionResult Edit(int id)
        {
            User userModel = context.Users.FirstOrDefault(a => a.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);  
        }


        [HttpPost]
        public IActionResult Edit(int id, User editUser)
        {         
            if(editUser.Password != null && editUser.Mobile != 0)
            {
                User userModel = context.Users.FirstOrDefault(a => a.Id == id);
                if(userModel != null)
                {
                    userModel.Mobile = editUser.Mobile;
                    userModel.Password = editUser.Password;
                    context.SaveChanges();
                    return RedirectToAction("Profile", new { id });
                }
            }
            return View("Edit", editUser);
        }

        public IActionResult ViewSchedule() 
        {
        

            int id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            // Retrieve the student's schedule data
            var branchId = context.Users.SingleOrDefault(a => a.Id == id).BranchId;
            var stdtrackint = context.StudentTrackIntakes.FirstOrDefault(a => a.StudentID == id);
            var trackId = stdtrackint.TrackID;
            var intakeId = stdtrackint.IntakeID;

            // Retrieve the last 5 records from the schedule table
            var lastFiveSchedules = context.TrackSchedules
                .Include(t => t.Schedule)
                .Where(t => t.BranchID == branchId && t.TrackID == trackId && t.IntakeID == intakeId)
                .OrderByDescending(t => t.Schedule.Date)
                .Take(5)
                .ToList();
            lastFiveSchedules.Reverse();

            return View(lastFiveSchedules);

        }
    }
}
