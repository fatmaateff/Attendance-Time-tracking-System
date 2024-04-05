using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.Models
{
    public class ProgramType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Duration { get; set; }
        public bool IsDeleted { get; set; } = false;
        //navigation properties
        public ICollection<Track> Tracks { get; set; }
    }
}
