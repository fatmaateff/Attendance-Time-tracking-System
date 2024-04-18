using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;
using Attendance_Time_tracking_System.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Attendance_Time_tracking_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly AttendanceSysDbContext db;

        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IIntakeRepository _intakeRepository;

        public AccountController(AttendanceSysDbContext _db ,
                                 IAttendanceRepository attendanceRepository,
                                 IScheduleRepository scheduleRepository ,
                                 IIntakeRepository intakeRepository)
        {
            db = _db;
            _attendanceRepository = attendanceRepository;
            _scheduleRepository = scheduleRepository;
            _intakeRepository = intakeRepository;
        }


        [HttpGet]
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
           
            RedirectToAction("Login");
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Login(LoginViewModel model)
        {
            // Check if the model is valid
            if(!ModelState.IsValid) {
                return View(model);
            }

            //authenticate the user
            var user = db.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            //check if the user exists in database or not
            if(user == null)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View();
            }
			//sign in the user

			//claim for every part of the user
            Claim claimEmail = new Claim(ClaimTypes.Email, user.Email);
            Claim claimRole;

           
            if (user.Role == "Employee")
            {
                Employee Emp = db.Employees?.FirstOrDefault(x => x.Id == user.Id);
                int EmpRoleEnum = (int)Emp.Type;

                string EmpRole; //= EmpRoleEnum == 0 ? "Security" : "StudentAffair";
                if(EmpRoleEnum == 0)
                {
                    EmpRole = "Security";

                    int intakeId = _intakeRepository.GetCurrentIntake().Id;

                    List<TrackSchedule> tracks = _scheduleRepository.TodaysTracksSchedules(user.BranchId, intakeId).ToList();

                    InitializeTracks(tracks);
                    
                    InitializeEmployees(user.BranchId);

                }
                else
                {
                    EmpRole = "StudentAffair";
                }
                claimRole = new Claim(ClaimTypes.Role, EmpRole);
            }
            else
                claimRole = new Claim(ClaimTypes.Role, user.Role.ToString());
            Claim claimId = new Claim(ClaimTypes.NameIdentifier, user.Id.ToString());
            

            // initialize day attendance for security


            ClaimsIdentity claimsIdentity1 = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            claimsIdentity1.AddClaim(claimEmail);
            claimsIdentity1.AddClaim(claimRole);
            claimsIdentity1.AddClaim(claimId);

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
            claimsPrincipal.AddIdentity(claimsIdentity1);
            await HttpContext.SignInAsync(claimsPrincipal);

            if(user.Role== "Employee")
            {
                Employee Emp = db.Employees.FirstOrDefault(x => x.Id == user.Id);
                int EmpRoleEnum = (int)Emp.Type;
                if (EmpRoleEnum == 1)
                    return RedirectToAction(nameof(Index), "StudentAffairs");
            }
            return RedirectToAction("Index", "Home");

        }

        //private void InitializeTracks(int branchId, int intakeId)
        private void InitializeTracks(List<TrackSchedule> tracks)
        {
            foreach (TrackSchedule track in tracks)
            {
                if (! _attendanceRepository.IsStudentsAttendanceInitialized(track.TrackID, track.IntakeID, track.BranchID))
                    _attendanceRepository.InitializeTrackAttendanceToday(track.TrackID, track.IntakeID, track.BranchID);
            }
        
        }

        private void InitializeEmployees(int branchId)
        {
            if (!_attendanceRepository.IsEmployeesAttendanceInitialized(branchId))
                _attendanceRepository.InitializeEmployeesAttendanceToday(branchId);
        }
    }
}
