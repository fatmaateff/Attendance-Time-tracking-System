using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Time_tracking_System.Models;

public class Attendance
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }


    public DateOnly Date { get; set; }


    [Display(Name = "Arrival Time")]
    public DateTime TimeIn { get; set; }


    [Display(Name = "Time out")]
    public DateTime? TimeOut { get; set; }

    [ForeignKey("User")]
    public int UserId { get;set; }

    public User User { get; set; }
}
