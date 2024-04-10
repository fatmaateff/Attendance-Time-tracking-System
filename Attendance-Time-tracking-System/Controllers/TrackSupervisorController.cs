using Attendance_Time_tracking_System.Models;
using Attendance_Time_tracking_System.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_Time_tracking_System.Controllers
{
    public class TrackSupervisorController : Controller
    {
        ITrackRepository TrackRepository;
        IInstructorRepository insRepository;
        ITrackSupervisorRepository TrackSupervisorRepository;
        public TrackSupervisorController(ITrackRepository _TrackRepository, IInstructorRepository _insRepository, ITrackSupervisorRepository _TrackSupervisorRepository)
        {
            TrackRepository = _TrackRepository;
            insRepository = _insRepository;
            TrackSupervisorRepository = _TrackSupervisorRepository;
        }
        //to assign supervisor for a track
        [HttpGet]
        public IActionResult AssignSupervisor(int id)
        {
            var instructor = insRepository.GetAll();
            var tracks = TrackRepository.GetAll();
            ViewBag.Instructors = instructor;
            ViewBag.Tracks = tracks;
            return View();
        }
        [HttpPost]
        public IActionResult AssignSupervisor(int trackId , int instructorId)
        {
            if(TrackSupervisorRepository.exists(trackId, instructorId))
            {
                ViewBag.Message = "This supervisor is already assigned to this track";
            }
            else
            {
                var trackSupervisor = new TrackSupervisor()
                {
                    TrackID = trackId,
                    InstructorID = instructorId
                };
                TrackSupervisorRepository.Add(trackSupervisor);
                ViewBag.Message = "Supervisor assigned successfully";
                
            }
            return View("Index");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
