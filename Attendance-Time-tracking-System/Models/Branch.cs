using Attendance_Time_tracking_System.Enums;
using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.Models;

public class Branch
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]

    [StringLength(100,MinimumLength =5)]
    public string Name { get; set; }

    [Required]
    public BranchStatus Status { get; set; }
}
