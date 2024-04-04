using Attendance_Time_tracking_System.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Time_tracking_System.Models;

public class Branch
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]

    [StringLength(100,MinimumLength =5)]
    public string Name { get; set; }

    [Required]
    public BranchStatus Status { get; set; }
    public bool IsDeleted { get; set; } = false;


    ICollection<User> Users = new HashSet<User>();
    ICollection<TrackSupervisor> supervisors = new HashSet<TrackSupervisor>();
    ICollection<TrackSchedule> Schedules = new HashSet<TrackSchedule>();

}
