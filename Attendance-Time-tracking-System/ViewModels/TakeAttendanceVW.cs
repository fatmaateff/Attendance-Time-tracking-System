
namespace Attendance_Time_tracking_System.ViewModels;

public class TakeAttendanceVW
{

    [Required]
    public string Id { get; set; }

    [Required]
    
    public DateOnly ArrivalDate { get; set; }

    [Required]
    public TimeOnly ArrivalTime { get; set; }

    public TimeOnly DepatureTime { get; set; }

}
