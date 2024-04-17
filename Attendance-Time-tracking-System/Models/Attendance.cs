using Attendance_Time_tracking_System.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Time_tracking_System.Models;

public class Attendance
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public AttendanceStatus Status { get; set; }


    [Display(Name = "Arrival Time")]
    public TimeOnly TimeIn { get; set; }


    [Display(Name = "Time out")]
    public TimeOnly? TimeOut { get; set; }
    public AttendanceStatus Status { get; set; }

    [ForeignKey("User")]
    public int UserId { get;set; }

    public virtual  User User { get; set; }
}
