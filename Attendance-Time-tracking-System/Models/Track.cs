using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.Models;

public class Track
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100 ,MinimumLength =5)]
    public string Name { get; set; }
}
