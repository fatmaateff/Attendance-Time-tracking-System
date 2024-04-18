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

        public List<Schedule> GetAllSchedules(int InstructorId)
        {
            TrackSupervisor trackSupervisor = db.TrackSupervisors.OrderByDescending(x => x.Intake.StartDate)
                .FirstOrDefault(i => i.InstructorID == InstructorId);
            List<int> ScheduleIds = db.TrackSchedules.Where(x => 
                x.IntakeID == trackSupervisor.IntakeID &&
                x.BranchID==trackSupervisor.BranchID &&
                x.TrackID==trackSupervisor.TrackID)
            .Select(x => x.ScheduleID).ToList();
            List<Schedule> schedules = new List<Schedule>();
            foreach (int id in ScheduleIds)
            {
                schedules.Add(db.Schedules.FirstOrDefault(x => x.Id == id));
            }
            return schedules;
        }
        public void AddSchedule(int InstructorId, Schedule schedule)
        {
            db.Schedules.Add(schedule);
            db.SaveChanges();
            int ScheduleId = db.Schedules.Select(x => x.Id).Max();
            TrackSupervisor trackSupervisor = db.TrackSupervisors.OrderByDescending(x => x.Intake.StartDate)
                .FirstOrDefault(i => i.InstructorID == InstructorId);
            TrackSchedule trackSchedule = new TrackSchedule()
            {
                ScheduleID = ScheduleId,
                IntakeID = trackSupervisor.IntakeID,
                BranchID = trackSupervisor.BranchID,
                TrackID = trackSupervisor.TrackID
            };
            db.TrackSchedules.Add(trackSchedule);
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

        public IEnumerable<TrackSchedule> TodaysTracksSchedules(int branchId ,int intakeId)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now.Date);


            IEnumerable<TrackSchedule> tracks = from track in db.TrackSchedules
                                                join schedule in db.Schedules
                                                on track.ScheduleID equals schedule.Id
                                                where track.IntakeID == intakeId
                                                        && track.BranchID == branchId
                                                        && schedule.Date == today
                                                select track;
                                                

            return tracks;
        }
    }
}
