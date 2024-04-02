using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.Models;

public class Intake
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(50,MinimumLength =5)]
    public string Name { get; set; }


    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }


    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; }

}
