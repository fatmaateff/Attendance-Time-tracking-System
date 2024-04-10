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
        public IActionResult showDetails(int id)
        {
            var instructor = InsRepository.GetById(id);
            return View(instructor);
        }
        [HttpGet]
        public IActionResult Edit (int id)
        {
            var instructor = InsRepository.GetById(id);
            return View(instructor);
        }
        [HttpPost]
        public IActionResult Edit(Instructor instructor )
        {
            if (ModelState.IsValid)
            {
                InsRepository.Update(instructor);
                return RedirectToAction("Index");
            }
            return View(instructor);
        }
    }
}

