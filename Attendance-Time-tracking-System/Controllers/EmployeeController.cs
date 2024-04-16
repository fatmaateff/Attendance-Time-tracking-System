using Attendance_Time_tracking_System.Enums;
using Attendance_Time_tracking_System.Models;
using Attendance_Time_tracking_System.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_Time_tracking_System.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepository employeeRepository;
        IBranchRepository BranchRepository;
        public EmployeeController(IEmployeeRepository _employeeRepository, IBranchRepository _branchRepository)
        {
            employeeRepository = _employeeRepository;
            BranchRepository = _branchRepository;
        }
        public IActionResult Index()
        {
            var employees = employeeRepository.GetAll();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.branches = BranchRepository.GetAll();
            ViewBag.Types = Enum.GetValues(typeof(EmpType)).Cast<EmpType>();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.Add(employee);
                return RedirectToAction("Index");
            }
            ViewBag.branches = BranchRepository.GetAll();
            ViewBag.Types = Enum.GetValues(typeof(EmpType)).Cast<EmpType>();
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.branches = BranchRepository.GetAll();
            ViewBag.Types = Enum.GetValues(typeof(EmpType)).Cast<EmpType>();
            var employee = employeeRepository.GetById(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.Update(employee);
                return RedirectToAction("Index");
            }
            ViewBag.branches = BranchRepository.GetAll();
            ViewBag.Types = Enum.GetValues(typeof(EmpType)).Cast<EmpType>();
            return View(employee);
        }
        public IActionResult showDetails(int id)
        {
            ViewBag.branches = BranchRepository.GetAll();
            var employee = employeeRepository.GetById(id);
            return View(employee);
        }
        public IActionResult Delete(int id)
        {
            employeeRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
