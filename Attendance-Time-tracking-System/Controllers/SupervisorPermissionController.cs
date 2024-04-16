using Attendance_Time_tracking_System.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Attendance_Time_tracking_System.Controllers
{
    public class SupervisorPermissionController : Controller
    {
        ISupervisorRepository supervisorRepository;
        public SupervisorPermissionController(ISupervisorRepository supervisorRepository)
        {
            this.supervisorRepository = supervisorRepository;   
        }
        public IActionResult Index()
        {
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var super=supervisorRepository.finduser(int.Parse(userIdClaim));
            var stdlist=supervisorRepository.getstudentid(super.TrackID);
            
            return View(supervisorRepository.getpermissions(stdlist));
        }
        public IActionResult acceptpermisssion(DateOnly date)
        {
            supervisorRepository.accept(date);
            return RedirectToAction("index");
        }
        public IActionResult refuse(DateOnly date) {

            supervisorRepository.refuse(date);
            return RedirectToAction("index");
        }
    }
}
