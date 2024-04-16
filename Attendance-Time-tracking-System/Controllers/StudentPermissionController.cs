using Attendance_Time_tracking_System.Models;
using Attendance_Time_tracking_System.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net.PeerToPeer;
using System.Security.Claims;

namespace Attendance_Time_tracking_System.Controllers
{
    public class StudentPermissionController : Controller
    {
        IStudentRepository studentRepository;
        public StudentPermissionController(IStudentRepository _repo)
        {
            studentRepository = _repo;

        }
        public IActionResult permissionnform()
        {
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewBag.countpermission = studentRepository.numofpermissions(int.Parse(userIdClaim));

            return View();
        }
        [HttpPost]
        public IActionResult permissionnform(Permission per)
        {
           
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (studentRepository.detectpermissioninsamedate(per,int.Parse( userIdClaim)))
            {
                ViewBag.message = "You have permission in the same date";
                return View();
            }
            studentRepository.addpermission(per,int.Parse(userIdClaim));
            ViewBag.countpermission = studentRepository.numofpermissions(int.Parse(userIdClaim));

            return View();
        }
        public IActionResult showpermissions()
        {
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            

            return View(studentRepository.allpermissions(int.Parse(userIdClaim)));
        }
        
        public IActionResult delete(DateOnly dateTime)
        {
            studentRepository.deletepermission(dateTime);
            ViewBag.deleted = true;
            return RedirectToAction("showpermissions");
        }
    }
}
