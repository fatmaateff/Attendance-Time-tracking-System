using Attendance_Time_tracking_System.Models;
using Attendance_Time_tracking_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_Time_tracking_System.Controllers
{
    [Authorize]
    public class InstructorController : Controller
    {
        IInstructorRepository InsRepository;
        public InstructorController(IInstructorRepository _InstructorRepository)
        {
            InsRepository = _InstructorRepository;
        }
        public IActionResult Index()
        {
            var instructors = InsRepository.GetAll();
            return View(instructors);
        }
        //public IActionResult Details(int id)
        //{
        //    var instructor = InsRepository.Get(id);
        //    return View(instructor);
        //}

        //create new instructor
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Instructor instructor)
        {
            InsRepository.Add(instructor);
            return RedirectToAction("Index");
        }
    }
}

