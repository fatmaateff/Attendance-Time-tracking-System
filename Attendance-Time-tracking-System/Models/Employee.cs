namespace Attendance_Time_tracking_System.Models
{
    public class Employee : User
    {
        [Required]
        public int Type { get; set; }
    }
}
