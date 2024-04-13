namespace Attendance_Time_tracking_System.Controllers;

public class AttendanceController : Controller
{
    private User currentUser;

    private readonly IBranchRepository _branchRepo;
    private readonly IAttendanceRepository _attendanceRepo;
    private readonly IUserRepository _userRepository;
    
    public AttendanceController(IAttendanceRepository attendanceRepository , IBranchRepository branchRepository, IUserRepository userRepository)
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

        IEnumerable<User> users;
        ViewBag.Title = role;

        if (role.Equals("Students",StringComparison.OrdinalIgnoreCase))
            users = _userRepository.GetStudents(branchId);
        else
            users = _userRepository.GetEmployees(branchId);

        return View(users);
    }


    public IActionResult Take(RoleType role ,int? trackId)
    {
        //int intakeId = 1;
        int branchId = currentUser.BranchId;

        IEnumerable<User> users;
        ViewBag.Role = role;
        if (role.Equals(RoleType.Student))
            users = _userRepository.GetStudents(branchId);
        else
            users = _userRepository.GetEmployees(branchId);

        return View(users);
    }

}
