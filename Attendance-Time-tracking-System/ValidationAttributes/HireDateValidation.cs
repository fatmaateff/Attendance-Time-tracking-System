using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.ValidationAttributes
{
    public class HireDateValidationAttribute : ValidationAttribute
    {
        private readonly AttendanceSysDbContext db = new AttendanceSysDbContext();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var instructor = (Instructor)validationContext.ObjectInstance;
            if (instructor.HireDate > DateTime.Now)
            {
                return new ValidationResult("Hire date cannot be in the future.");
            }
            return ValidationResult.Success;
        }
    }
}
