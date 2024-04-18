using Attendance_Time_tracking_System.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.Models
{
    public class Instructor : User
    {
        [DataType(DataType.Date)]
        [HireDateValidation]
        public DateTime HireDate { get; set; }

    }
}
