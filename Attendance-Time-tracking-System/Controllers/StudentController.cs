using Attendance_Time_tracking_System.Enums;
using Attendance_Time_tracking_System.Models;
using Attendance_Time_tracking_System.Repositories;
using Attendance_Time_tracking_System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Attendance_Time_tracking_System.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        IAttendanceRepository attendanceRepository;
        public StudentController(IAttendanceRepository _attendanceRepository)
        {
            attendanceRepository = _attendanceRepository;
        }
        public IActionResult ViewAttendance()
        {
            StudentAttendanceGradeViewModel studentAttendanceGradeVM = new StudentAttendanceGradeViewModel();
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            studentAttendanceGradeVM.attendances = attendanceRepository.GetAttendanceById(userId);
            studentAttendanceGradeVM.Late = studentAttendanceGradeVM.attendances.Count(a => a.Status == AttendanceStatus.Late);
            studentAttendanceGradeVM.Absent = studentAttendanceGradeVM.attendances.Count(a => a.Status == AttendanceStatus.Absent);
            studentAttendanceGradeVM.Grade = GetGrade(studentAttendanceGradeVM.Absent+ studentAttendanceGradeVM.Late);
            return View(studentAttendanceGradeVM);
        }
        public IActionResult ViewLateAttendance()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            List<Attendance> attendances = attendanceRepository.GetLateAttendanceById(userId);
            return PartialView("ViewLatePartialViews",attendances);
        }
        public IActionResult ViewAbsentAttendance()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            List<Attendance> attendances = attendanceRepository.GetAbsentAttendanceById(userId);
            return PartialView("ViewAbsentPartialViews", attendances);
        }
        public IActionResult ViewAttendentAttendance()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            List<Attendance> attendances = attendanceRepository.GetAttendentAttendanceById(userId);
            return PartialView("ViewAttendentPartialViews", attendances);
        }

        public int GetGrade(int DaysOff)
        {
            int[] prefixMinus = { 0, 5, 15, 30, 55 };
            int Grade = 250;
            if (DaysOff < 2) return Grade;
            DaysOff--;
            int Whole = Math.Min(DaysOff / 3, 3);
            int rem = (Whole == 0 ? DaysOff : DaysOff % (Whole * 3));
            if (Whole < 3)
                Grade -= prefixMinus[Whole] * 3 + rem * (prefixMinus[Whole + 1] - prefixMinus[Whole]);
            else
                Grade -= prefixMinus[Whole] * 3 + rem * 25;
            return Grade;
        }
    }
}
