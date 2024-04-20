using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;
using Attendance_Time_tracking_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Attendance_Time_tracking_System.Controllers
{
    [Authorize]
	public class StudentAffairsController : Controller
	{
		IStudentRepository studentRepository;
		ITrackRepository trackRepository;
		public StudentAffairsController (IStudentRepository studentRepository ,ITrackRepository trackRepository)
		{
			this.studentRepository = studentRepository;
			this.trackRepository = trackRepository;
		}
        public IActionResult Index()
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
		public IActionResult add (AddStudentViewModel std) {
            studentRepository.add(std);

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
