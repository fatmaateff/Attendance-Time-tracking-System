using Attendance_Time_tracking_System.Models;
using Attendance_Time_tracking_System.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.ValidationAttributes
{
    public class TimeValidationAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Schedule schedule = (Schedule)validationContext.ObjectInstance;

            if (schedule.StartTime<schedule.EndTime)
                return ValidationResult.Success;
            return new ValidationResult("End Time Must be greater then Start Time");

        }
    }
}
