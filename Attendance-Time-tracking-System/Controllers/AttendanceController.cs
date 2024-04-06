using Attendance_Time_tracking_System.Enums;
using Attendance_Time_tracking_System.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_Time_tracking_System.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IBranchRepository _branchRepo;
        private readonly IAttendanceRepository _attendanceRepo;

        public AttendanceController(IAttendanceRepository attendanceRepository , IBranchRepository branchRepository)
        {
            _attendanceRepo = attendanceRepository;
            _branchRepo = branchRepository;
        }

        public IActionResult Index(UserType userType ,int? trackId)
        {
            int branchId = 1;
            int intakeId = 1;
            

            if(userType.Equals(UserType.Stundent))
            {
                ViewBag.Tracks = _branchRepo.GetTracksInBranch(branchId);
                AttendanceIndexVM attendanceIndexVM = new AttendanceIndexVM()
                {
                    Students = _branchRepo.GetBranchStundents(branchId, intakeId, trackId),
                    IsStudent = true
                };
                return View(attendanceIndexVM);
            }
            else if(userType.Equals(UserType.Employee))
            {
                AttendanceIndexVM attendanceIndexVM = new AttendanceIndexVM()
                {
                    Students = _branchRepo.GetBranchStundents(branchId, intakeId, trackId),
                    IsStudent = false
                };
                return View(attendanceIndexVM);
            }





            return View(stundets);
        }
    }
}
