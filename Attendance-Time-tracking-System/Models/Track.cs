using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Time_tracking_System.Models;

public class Track
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(100 ,MinimumLength =5)]
    public string Name { get; set; }
    [ForeignKey("ProgramType")]
    public int ProgramID { get; set; }
    public bool IsDeleted { get; set; } = false;

    public virtual ProgramType ProgramType { get; set; }

    ICollection<StudentTrackIntake> Studnets = new HashSet<StudentTrackIntake>();

    ICollection<TrackSupervisor> Supervisors = new HashSet<TrackSupervisor>();

    ICollection<TrackSupervisor> Schedules = new HashSet<TrackSupervisor>();


}
