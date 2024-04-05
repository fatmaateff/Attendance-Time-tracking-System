﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance_Time_tracking_System.Models
{
    public class TrackSupervisor
    {
        [ForeignKey("Instructor")]
        public int InstructorID { get; set; }
        [ForeignKey("Intake")]
        public int IntakeID { get; set; }
        [Required, ForeignKey("Branch")]
        public int BranchID { get; set; }
        [Required, ForeignKey("Track")]
        public int TrackID { get; set; }

        //navigation properties
        public Instructor Instructor { get; set; }
        public Intake Intake { get; set; }
        public Branch Branch { get; set; }
        public Track Track { get; set; }
    }
}
