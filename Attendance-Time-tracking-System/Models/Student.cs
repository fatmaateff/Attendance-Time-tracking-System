using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Time_tracking_System.Models
{
    public class Student : User
    {
        public string University { get; set; }
        public string Faculty { get; set; }
        public string Specialization { get; set; }
        public int GradYear { get; set; }
        public bool Status { get; set; }
        
        //student has many Permissions
        public ICollection<Permission> Permissions { get; set; } = new HashSet<Permission>();

        //student is at only one track
        public int TrackId { get; set; }
        [ForeignKey("TrackId")]

        //navigation property for Track
        public Track TrackNavigation { get; set; }

    }
}
