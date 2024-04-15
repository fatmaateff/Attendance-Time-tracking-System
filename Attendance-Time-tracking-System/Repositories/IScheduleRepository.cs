using Attendance_Time_tracking_System.Models;

namespace Attendance_Time_tracking_System.Repositories
{
    public interface IScheduleRepository
    {
        List<Schedule> GetAllSchedules();
        void AddSchedule(Schedule schedule);
        void EditSchedule(int id, Schedule schedule);
        Schedule GetScheduleById(int id);
        void DeleteScheduleById(int id);
        bool IsUniqueDate(DateOnly date);
    }
}