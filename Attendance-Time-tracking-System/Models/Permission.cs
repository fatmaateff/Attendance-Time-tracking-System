using Attendance_Time_tracking_System.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Time_tracking_System.Models;

public class Permission
{

    public DateOnly Date { get; set; }

    public PermissionType Type { get; set; }

    public PermissionStatus Status{ get; set; }

    [Required]
    [StringLength(100, MinimumLength =10)]
    public string Reason { get; set; }


    [ForeignKey(nameof(Student))]
    public int StdId { get; set; }


    public Student Student { get; set; }

}
