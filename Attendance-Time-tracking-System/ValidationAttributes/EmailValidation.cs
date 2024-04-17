﻿using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Attendance_Time_tracking_System.ValidationAttributes
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        private readonly AttendanceSysDbContext db = new AttendanceSysDbContext();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string email = value.ToString();
                //check if email already exists
                var user = db.Users.FirstOrDefault(e => e.Email == email);
                if(user == null)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("This email address is already in use.");
            }
            return new ValidationResult("Email Address is Required.");

        }
    }
}