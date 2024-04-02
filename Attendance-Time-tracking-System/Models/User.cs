using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Time_tracking_System.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public long Mobile { get; set; }

        // foreign key for Branch
        public int BranchId { get; set; }
        //[ForeignKey("BranchId")]

        //navigation property for Branch
        //public Branch BranchNavigation { get; set; }

        //user has many attendances
        //public ICollection<Attendance> Attendances { get; set; } = new HashSet<Attendance>();
    }
}
