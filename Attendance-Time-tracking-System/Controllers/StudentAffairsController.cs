using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;
using Attendance_Time_tracking_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using System.Security.Claims;

namespace Attendance_Time_tracking_System.Controllers
{
    [Authorize]
	public class StudentAffairsController : Controller
	{
		IStudentRepository studentRepository;
		ITrackRepository trackRepository;
        private User _currentUser;
        private readonly IUserRepository _userRepository;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IIntakeRepository _intakeRepository;


        public StudentAffairsController (IStudentRepository studentRepository ,
                                        ITrackRepository trackRepository,
                                        IUserRepository userRepository,
                                        IAttendanceRepository attendanceRepository ,
                                        IBranchRepository branchRepository ,
                                        IIntakeRepository intakeRepository)
		{
			this.studentRepository = studentRepository;
			this.trackRepository = trackRepository;
            _userRepository = userRepository;
            _attendanceRepository = attendanceRepository;
            _branchRepository = branchRepository;
            _intakeRepository = intakeRepository;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _currentUser = _userRepository.GetUserById(int.Parse(userId));
            base.OnActionExecuting(context);
        }


        public IActionResult Index(int? trackId , DateOnly? date)
		{
            try
            {
                int intakeId = _intakeRepository.GetCurrentIntake().Id;

                IEnumerable<Track> tracks = _branchRepository.GetTracksInBranch(_currentUser.BranchId, intakeId);

                ViewBag.Tracks = new SelectList(tracks, nameof(Track.Id), nameof(Track.Name));

                if (date is null)
                    date = DateOnly.FromDateTime(DateTime.Now);

                if (trackId is null)
                    trackId = tracks.FirstOrDefault()?.Id ?? -1;

                IEnumerable<UserAttendanceVM> userAttendanceCollection = _attendanceRepository.GetTrackAttendance(trackId.Value, _currentUser.BranchId, intakeId, date.Value);

                return View(userAttendanceCollection);

            }
            catch
            {
                return View("Error");
            }

        }

        public IActionResult EditAttendance(int userId ,DateOnly date)
        {
            Attendance attendance = _attendanceRepository.GetUserAttendance(userId, date);

            return View(attendance);
        }


        [HttpPost]
        public IActionResult EditAttendance(Attendance attendance)
        {
            _attendanceRepository.TryAlterUserAttendance(attendance);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditStudents()
        {
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            return View(studentRepository.getall(int.Parse(userIdClaim)));
        }
        public IActionResult Delete(int id) 
		{ 
			studentRepository.delete(id);
			return RedirectToAction("index");
		}
		public IActionResult Add ()
		{ 
			ViewBag.tracks=trackRepository.GetAll();
			return View();
		}
		[HttpPost]
		public IActionResult add (AddStudent std) {
            var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            

            studentRepository.add(std ,int.Parse(userIdClaim));

			return RedirectToAction("index");
		}
        [HttpPost]

        public IActionResult UploadExcel(IFormFile file)
		{
            try
            {
                if (file != null && file.Length > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);

                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    studentRepository.ImportDataFromExcel(filePath);

                    ViewBag.Message = "Bulk insert from Excel to database successful!";
                }
                else
                {
                    ViewBag.Message = "No file uploaded.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
            }

            return RedirectToAction("index");
        }

    }
}
