using Attendance_Time_tracking_System.Enums;
using Attendance_Time_tracking_System.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Attendance_Time_tracking_System.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IBranchRepository _branchRepo;
        private readonly IAttendanceRepository _attendanceRepo;
        private readonly IUserRepository _userRepository;
        private User currentUser;
        
        public AttendanceController(IAttendanceRepository attendanceRepository , IBranchRepository branchRepository, IUserRepository userRepository)
        {
            _attendanceRepo = attendanceRepository;
            _branchRepo = branchRepository;
            _userRepository = userRepository;
        }
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            base.OnActionExecuting(context);
        }
        
        public IActionResult Index(RoleType role ,int? trackId)
        {
            int branchId = 1;
            int intakeId = 1;

            AttendanceIndexVM attendanceIndexVM;
        
            if (role.Equals(RoleType.Student))
            {
                IEnumerable<Track>  tracks = _branchRepo.GetTracksInBranch(branchId);
                ViewBag.TracksSL = new SelectList(tracks,nameof(Track.Id), nameof(Track.Name));
                attendanceIndexVM = new AttendanceIndexVM()
                {
                    Students = _branchRepo.GetBranchStundents(branchId, intakeId, trackId),
                    IsStudent = true
                };
            }
            else if(role.Equals(RoleType.Instructor))
            {
                attendanceIndexVM = new AttendanceIndexVM()
                {
                    Users = _userRepository.GetInstructor(branchId),
                    IsStudent = false
                };
            }
            else
            {
                attendanceIndexVM = new AttendanceIndexVM()
                {
                    Users = _userRepository.GetEmployees(branchId),
                    IsStudent = false
                };
            }

            return View(attendanceIndexVM);
        }
    }
}
