﻿using Attendance_Time_tracking_System.Data;

namespace Attendance_Time_tracking_System.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        AttendanceSysDbContext db;
        public ProgramRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }
    }
}
