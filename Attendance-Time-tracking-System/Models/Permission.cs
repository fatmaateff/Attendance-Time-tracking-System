using Attendance_Time_tracking_System.Enums;
using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.Models;

public class Permission
{


    [Required]
    public DateTime Date { get; set; }

    [Required]
    public PermissionType Type { get; set; }


    [Required]
    public PermissionStatus Status{ get; set; }


    [Required]
    [StringLength(100, MinimumLength =10)]
    public string? Reason { get; set; }

}
