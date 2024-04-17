using Attendance_Time_tracking_System.Models;
using Attendance_Time_tracking_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace Attendance_Time_tracking_System.Controllers
{
    [Authorize]
    public class TrackController : Controller
    {
        ITrackRepository trackRepository;
        IProgramRepository ProgramRepository;
        public TrackController(ITrackRepository _trackRepository, IProgramRepository _programRepository)
        {
            trackRepository = _trackRepository;
            ProgramRepository = _programRepository;
        }
        public IActionResult Index()
        {
            ViewBag.programs = ProgramRepository.GetAll();
            var tracks = trackRepository.GetAll();
            return View(tracks);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Track track)
        {
            if(ModelState.IsValid)
            {
                trackRepository.Add(track);
                return RedirectToAction("Index");
            }
            return View(track);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var track = trackRepository.GetById(id);
            return View(track);
        }
        [HttpPost]
        public IActionResult Edit(Track track)
        {
            if (ModelState.IsValid)
            {
                trackRepository.Update(track);
                return RedirectToAction("Index");
            }
            return View(track);
        }
        public IActionResult showDetails(int id)
        {
            var track = trackRepository.GetById(id);
            return View(track);
        }
        public IActionResult Delete(int id)
        {
            trackRepository.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}
