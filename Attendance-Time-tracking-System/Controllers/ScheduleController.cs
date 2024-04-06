using Attendance_Time_tracking_System.Models;
using Attendance_Time_tracking_System.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_Time_tracking_System.Controllers
{
    public class ScheduleController : Controller
    {
        IScheduleRepository scheduleRepository;
        public ScheduleController(IScheduleRepository _scheduleRepository)
        {
            scheduleRepository = _scheduleRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowSchedules()
        {
            return View(scheduleRepository.GetAllSchedules());
        }
        public IActionResult AddForm()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Schedule schedule)
        {
            if(ModelState.IsValid)
            {
                scheduleRepository.AddSchedule(schedule);
                return RedirectToAction("ShowSchedules");
            }
            return View("AddForm", schedule);
        }
        public IActionResult EditForm(int id)
        {            
            return View(scheduleRepository.GetScheduleById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Schedule schedule)
        {
            if(ModelState.IsValid)
            {
                scheduleRepository.EditSchedule(id,schedule);
                return RedirectToAction("ShowSchedules");
            }
            return View("EditForm", schedule);
        }
        public IActionResult Delete(int id)
        {
            scheduleRepository.DeleteScheduleById(id);
            return RedirectToAction("ShowSchedules");
        }
    }
}
