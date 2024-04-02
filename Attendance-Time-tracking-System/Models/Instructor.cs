namespace Attendance_Time_tracking_System.Models
{
    public class Instructor : User
    {
        public DateTime HireDate { get; set; }

        //instructor in many Tracks
        //public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
    }
}
