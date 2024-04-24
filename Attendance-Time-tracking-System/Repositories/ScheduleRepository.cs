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

        public List<Schedule> GetSchedules(int InstructorId)
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
        public List<Schedule> GetSchedules(int InstructorId, DateOnly StartDate,DateOnly EndDate)
        {
            TrackSupervisor trackSupervisor = db.TrackSupervisors.OrderByDescending(x => x.Intake.StartDate)
                .FirstOrDefault(i => i.InstructorID == InstructorId);
            List<int> ScheduleIds = db.TrackSchedules.Where(x =>
                x.IntakeID == trackSupervisor.IntakeID &&
                x.BranchID == trackSupervisor.BranchID &&
                x.TrackID == trackSupervisor.TrackID &&
                x.Schedule.Date>=StartDate &&
                x.Schedule.Date <= EndDate)
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
        public Schedule GetScheduleByDate(DateOnly date)
        {
            return db.Schedules.FirstOrDefault(s => s.Date == date);
        }
        public Schedule ValidateScheduleDateExistence(int insId,DateOnly date)
        {
            DateTime now = DateTime.Now;
            DateOnly today = new DateOnly(now.Year, now.Month, now.Day);
            int intakeId = db.Intakes.OrderBy(x => x.StartDate)
                .FirstOrDefault(x => (today >= x.StartDate && today <= x.EndDate) || today < x.StartDate).Id;

            TrackSupervisor trackSupervisor = db.TrackSupervisors
                .FirstOrDefault(x => x.InstructorID == insId && x.IntakeID == intakeId);

            TrackSchedule trackSchedule =  db.TrackSchedules
                                            .FirstOrDefault(x => x.IntakeID == intakeId &&
                                                x.BranchID == trackSupervisor.BranchID &&
                                                x.TrackID == trackSupervisor.TrackID &&
                                                x.Schedule.Date == date);
            return trackSchedule == null ? null : trackSchedule.Schedule;
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
