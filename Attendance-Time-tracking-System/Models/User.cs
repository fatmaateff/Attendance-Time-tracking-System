using Attendance_Time_tracking_System.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Attendance_Time_tracking_System.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3) , MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email Address")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6) , MaxLength(50)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        [Range(10000000000, 99999999999, ErrorMessage = "Mobile number must be 11 digits")]
        public long Mobile { get; set; }

        // user has one branch
        [Required(ErrorMessage = "Branch is required")]
        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        public bool IsDeleted { get; set; }
        //[Required]
        public Branch Branch { get; set; }
        public ICollection<Attendance> Attendances { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
