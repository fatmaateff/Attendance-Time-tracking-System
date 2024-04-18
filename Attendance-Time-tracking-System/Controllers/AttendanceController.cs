namespace Attendance_Time_tracking_System.Controllers;

public class AttendanceController : Controller
{
    private User currentUser;

    private readonly IBranchRepository _branchRepo;
    private readonly IAttendanceRepository _attendanceRepo;
    private readonly IUserRepository _userRepository;

    public AttendanceController(IAttendanceRepository attendanceRepository, IBranchRepository branchRepository, IUserRepository userRepository)
    {
        _attendanceRepo = attendanceRepository;
        _branchRepo = branchRepository;
        _userRepository = userRepository;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        currentUser = _userRepository.GetUserById(int.Parse(userId));
        base.OnActionExecuting(context);
    }

    public IActionResult Index(string role)
    {
        int branchId = currentUser.BranchId;
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);

        IEnumerable<User> users;

        ViewBag.Title = role;

        if (role.Equals("Student", StringComparison.OrdinalIgnoreCase))
            users = _userRepository.GetStudentsWithAttedance(branchId,today);
        else
            users = _userRepository.GetEmployeesWithAttedance(branchId,today);

        return View(users);
    }

    [HttpPost]
    public IActionResult MarkAttendace(int userId,DateTime dateTime)
    {
        User user = _userRepository.GetUserById(userId);
        
        if (user == null)
            return BadRequest();

        Attendance attendance = new Attendance();
        attendance.UserId = userId;
        attendance.TimeIn = TimeOnly.FromDateTime(dateTime);
        attendance.Date = DateOnly.FromDateTime(dateTime);


        TimeOnly targetTime = new TimeOnly(9, 15);

        if (targetTime.CompareTo(attendance.TimeIn) == -1)
            attendance.Status = AttendanceStatus.Late;
        else
            attendance.Status = AttendanceStatus.Attendant;

        bool inserted = _attendanceRepo.TryMarkUserAttendance(attendance);
        if (! inserted)
            return BadRequest();

        return View();
    }

    [HttpPost]
    public IActionResult MarkDeparture(int userId,DateTime dateTime)
    {
        User user = _userRepository.GetUserById(userId);

        if (user == null)
            return BadRequest();

        DateOnly date = DateOnly.FromDateTime(dateTime);

        Attendance attendance = new Attendance();
        attendance.UserId = userId;
        attendance.TimeOut = TimeOnly.FromDateTime(dateTime);
        attendance.Date = DateOnly.FromDateTime(dateTime);


        _attendanceRepo.TryMarkDeparture(attendance);

        return View();
    }

    [HttpPost]
    public IActionResult ResetAttendance(int userId, DateTime date)
    {
        User user = _userRepository.GetUserById(userId);
        if (user == null)
            return BadRequest();

        bool resetSuccessfully = _attendanceRepo.TryResetAttendance(userId,DateOnly.FromDateTime(date));
      
        if (resetSuccessfully)
            return View();
        else
            return BadRequest();
    }
}
