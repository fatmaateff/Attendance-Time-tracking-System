using Attendance_Time_tracking_System.Models;
using Attendance_Time_tracking_System.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Time_tracking_System.Controllers
{
    public class TrackSupervisorController : Controller
    {
        ITrackRepository TrackRepository;
        IInstructorRepository insRepository;
        ITrackSupervisorRepository TrackSupervisorRepository;
        IIntakeRepository IntakeRepository;
        IBranchRepository BranchRepository;

        public TrackSupervisorController(ITrackRepository _TrackRepository, IInstructorRepository _insRepository, ITrackSupervisorRepository _TrackSupervisorRepository, IIntakeRepository _intakeRepository, IBranchRepository _branchRepository)
        {
            TrackRepository = _TrackRepository;
            insRepository = _insRepository;
            TrackSupervisorRepository = _TrackSupervisorRepository;
            IntakeRepository = _intakeRepository;
            BranchRepository = _branchRepository;
        }
        //to assign supervisor for a track
        [HttpGet]
        public IActionResult AssignSupervisor(int id)
        {
            var instructor = insRepository.GetAll();
            var tracks = TrackRepository.GetAll();
            var intake = IntakeRepository.GetAll();
            var branch = BranchRepository.GetAll();
            ViewBag.Instructors = instructor;
            ViewBag.Tracks = tracks;
            ViewBag.Intakes = intake;
            ViewBag.Branches = branch;

            return View();
        }
        [HttpPost]
        public IActionResult AssignSupervisor(int trackId, int instructorId, int intakeId, int branchId)
        {
            try
            {
                if (TrackSupervisorRepository.exists(trackId, intakeId, branchId))
                {
                    ModelState.AddModelError("", "This track is already have supervisor");
                }
                else if (TrackSupervisorRepository.Exists(trackId,instructorId, intakeId, branchId))
                {
                    ModelState.AddModelError("", "This supervisor is already assigned to this track");
                }
                else
                {
                    var trackSupervisor = new TrackSupervisor
                    {
                        TrackID = trackId,
                        InstructorID = instructorId,
                        IntakeID = intakeId,
                        BranchID = branchId
                    };
                    TrackSupervisorRepository.Add(trackSupervisor);
                    insRepository.UpdateRoleToSupervisor(instructorId);

                    return RedirectToAction("Index");
                }

                var instructor = insRepository.GetAll();
                var tracks = TrackRepository.GetAll();
                var intake = IntakeRepository.GetAll();
                var branch = BranchRepository.GetAll();
                ViewBag.Instructors = instructor;
                ViewBag.Tracks = tracks;
                ViewBag.Intakes = intake;
                ViewBag.Branches = branch;
                return View();
            }
            catch (DbUpdateException ex)
            {
                // Check if the exception is due to a violation of the primary key constraint
                if (ex.InnerException is SqlException sqlException && sqlException.Number == 2627)
                {
                    ModelState.AddModelError("", "A supervisor is already assigned to another track");
                }
                else
                {
                    // If it's another type of exception, you might want to log it for debugging purposes
                    // Log the exception here
                    ModelState.AddModelError("", "An error occurred while assigning supervisor to track");
                }

                // Retrieve the necessary data for the view and return
                var instructor = insRepository.GetAll();
                var tracks = TrackRepository.GetAll();
                var intake = IntakeRepository.GetAll();
                var branch = BranchRepository.GetAll();
                ViewBag.Instructors = instructor;
                ViewBag.Tracks = tracks;
                ViewBag.Intakes = intake;
                ViewBag.Branches = branch;
                return View();
            }
        }

        public IActionResult Index()
        {
            var trackSupervisors = TrackSupervisorRepository.GetAll();
            return View(trackSupervisors);
        }
    }
}
