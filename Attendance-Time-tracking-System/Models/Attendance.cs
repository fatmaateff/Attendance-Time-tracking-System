using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Time_tracking_System.Models;

public class Attendance
{
    [Key]
    public Guid Id { get; set; }


    [Required]
    public DateOnly Date { get; set; }


    [Display(Name = "Arrival Time")]
    [Required]
    public DateTime TimeIn { get; set; }


    [Display(Name = "Time out")]
    public DateTime DateOut { get; set; }

}
