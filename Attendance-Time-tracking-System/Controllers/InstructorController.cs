using Attendance_Time_tracking_System.Enums;
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
        IBranchRepository BranchRepository;
        public InstructorController(IInstructorRepository _InstructorRepository, IBranchRepository _branchRepository)
        {
            InsRepository = _InstructorRepository;
            BranchRepository = _branchRepository;
        }

        public IActionResult Index()
        {
            var instructors = InsRepository.GetAll();
            ViewBag.branches = BranchRepository.GetAll();
            return View(instructors);
        }

        //create new instructor
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.branches = BranchRepository.GetAll();
            ViewBag.Roles = Enum.GetValues(typeof(RoleType)).Cast<RoleType>();
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
        public IActionResult Edit(int id)
        {
            ViewBag.branches = BranchRepository.GetAll();
            ViewBag.Roles = Enum.GetValues(typeof(RoleType)).Cast<RoleType>();
            var instructor = InsRepository.GetById(id);
            return View(instructor);
        }
        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            ViewBag.branches = BranchRepository.GetAll();
            InsRepository.Update(instructor);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Instructor instructor)
        {
            InsRepository.Delete(instructor.Id);
            return RedirectToAction("Index");
        }

    }
}