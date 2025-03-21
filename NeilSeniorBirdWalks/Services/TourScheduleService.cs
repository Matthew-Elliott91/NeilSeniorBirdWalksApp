using Microsoft.EntityFrameworkCore;
using NeilSeniorBirdWalks.Data;
using NeilSeniorBirdWalks.Models;

namespace NeilSeniorBirdWalks.Services
{
    public class TourScheduleService
    {
        private readonly ApplicationDbContext _context;
        public TourScheduleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TourSchedule>> GetAllSchedulesAsync()
        {
            return await _context.TourSchedules
                .Include(ts => ts.Tour)
                .ToListAsync();
        }

        public async Task<List<TourSchedule>> GetUpcomingSchedulesAsync()
        {
            return await _context.TourSchedules
                .Include(ts => ts.Tour)
                .Where(ts => ts.StartDateTime >= DateTime.Now)
                .OrderBy(ts => ts.StartDateTime)
                .ToListAsync();
        }

        public async Task<List<TourSchedule>> GetSchedulesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.TourSchedules
                .Include(ts => ts.Tour)
                .Where(ts => ts.StartDateTime >= startDate && ts.StartDateTime <= endDate)
                .OrderBy(ts => ts.StartDateTime)
                .ToListAsync();
        }

        public async Task<List<TourSchedule>> GetSchedulesForTourAsync(int tourId)
        {
            return await _context.TourSchedules
                .Where(ts => ts.TourId == tourId)
                .OrderBy(ts => ts.StartDateTime)
                .ToListAsync();
        }

        public async Task<TourSchedule> GetScheduleByIdAsync(int id)
        {
            return await _context.TourSchedules
                .Include(ts => ts.Tour)
                .FirstOrDefaultAsync(ts => ts.Id == id);
        }

        public async Task<TourSchedule> CreateScheduleAsync(TourSchedule schedule)
        {
            _context.TourSchedules.Add(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public async Task UpdateScheduleAsync(TourSchedule schedule)
        {
            _context.TourSchedules.Update(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteScheduleAsync(int id)
        {
            var schedule = await _context.TourSchedules.FindAsync(id);
            if (schedule != null)
            {
                _context.TourSchedules.Remove(schedule);
                await _context.SaveChangesAsync();
            }
        }
    }
}
