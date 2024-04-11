using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Time_tracking_System.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }    
        [Required]
        public string Role { get; set; }
        public long Mobile { get; set; }

        // user has one branch
        [Required]
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public bool IsDeleted { get; set; }
        //[Required]
        public Branch Branch { get; set; }
        public ICollection<Attendance> Attendances { get; set; }

    }

}
