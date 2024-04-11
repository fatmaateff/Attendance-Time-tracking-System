using Attendance_Time_tracking_System.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_Time_tracking_System.Controllers
{
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
            //ViewBag.programs = ProgramRepository.GetAll();
            var tracks = trackRepository.GetAll();
            return View(tracks);
        }
    }
}
