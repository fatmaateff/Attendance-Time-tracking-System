using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Time_tracking_System.Models;

public class Intake
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [StringLength(50,MinimumLength =5)]
    public string Name { get; set; }


    [Display(Name = "Start Date")]
    public DateOnly StartDate { get; set; }


    [Display(Name = "End Date")]
    public DateOnly EndDate { get; set; }


    ICollection<StudentTrackIntake> Students = new HashSet<StudentTrackIntake>();

    ICollection<TrackSupervisor> Supervisors = new HashSet<TrackSupervisor>();

    ICollection<TrackSchedule> Schedules = new HashSet<TrackSchedule>();

}
