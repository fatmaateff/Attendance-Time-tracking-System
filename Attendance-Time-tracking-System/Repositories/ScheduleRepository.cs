using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AttendanceSysDbContext db;
        public ScheduleRepository(AttendanceSysDbContext _db)
        {
            db = _db;
        }

        public List<Schedule> GetAllSchedules()
        {
            return db.Schedules.ToList();
        }
        public void AddSchedule(Schedule schedule)
        {
            db.Schedules.Add(schedule);
            db.SaveChanges();
        }
        public void EditSchedule(int id,Schedule schedule)
        {
            Schedule oldSchedule = db.Schedules.FirstOrDefault(s => s.Id == id);
            if (oldSchedule != null)
            {
                oldSchedule.Date = schedule.Date;
                oldSchedule.StartTime = schedule.StartTime;
                oldSchedule.EndTime = schedule.EndTime;
                oldSchedule.Subject = schedule.Subject;
                db.SaveChanges();
            }
        }
        public Schedule GetScheduleById(int id)
        {
            return db.Schedules.FirstOrDefault(s => s.Id == id);
        }
        public void DeleteScheduleById(int id)
        {
            Schedule schedule = db.Schedules.FirstOrDefault(s => s.Id == id);
            if (schedule != null)
            {
                db.Remove(schedule);
                db.SaveChanges();
            }
        }
        public bool IsUniqueDate(DateOnly date)
        {
            return db.Schedules.FirstOrDefault(s => s.Date == date) == null;
        }
    }
}
