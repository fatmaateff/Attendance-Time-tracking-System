using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;
using Attendance_Time_tracking_System.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_Time_tracking_System.Controllers
{
	public class StudentAffairsController : Controller
	{
		IStudentRepository studentRepository;
		public StudentAffairsController (IStudentRepository studentRepository)
		{
			this.studentRepository = studentRepository;
		}
        public IActionResult Index()
		{
            
            return View(studentRepository.getall());
		}
		public IActionResult Delete(int id) 
		{ 
			studentRepository.delete(id);
			return RedirectToAction("index");
		}
		public IActionResult Add ()
		{ 
			return View();
		}
	}
}
