using Attendance_Time_tracking_System.Data;
using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.ValidationAttributes
{
    public class mobileValidationAttribute : ValidationAttribute
    {
        private readonly AttendanceSysDbContext db = new AttendanceSysDbContext();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                long mobile = (long)value;
                //check if mobile already exists
                var userNumber = db.Users.FirstOrDefault(e => e.Mobile == mobile);
                if (userNumber == null)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("This mobile number is already in use.");
            }
            return new ValidationResult("Mobile Number is Required.");
        }

    }
}
