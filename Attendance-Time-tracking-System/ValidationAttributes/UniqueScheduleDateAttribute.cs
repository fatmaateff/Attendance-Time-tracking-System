using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;
using Attendance_Time_tracking_System.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Attendance_Time_tracking_System.ValidationAttributes
{
    public class UniqueScheduleDateAttribute:ValidationAttribute
    {
        //dep inj doesn't work here idk why:(
        AttendanceSysDbContext _db = new AttendanceSysDbContext();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateOnly date = (DateOnly)value;
            Schedule NewSchedule = (Schedule)validationContext.ObjectInstance;
            Schedule OldSchedule = _db.Schedules.FirstOrDefault(x => x.Date == date);
            if (OldSchedule == null || NewSchedule.Id == OldSchedule.Id)
                return ValidationResult.Success;
            return new ValidationResult("Date already exists");
        }
    }
}
