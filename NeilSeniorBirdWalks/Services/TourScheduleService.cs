using Microsoft.EntityFrameworkCore;
using NeilSeniorBirdWalks.Data;
using NeilSeniorBirdWalks.Models;

namespace NeilSeniorBirdWalks.Services
{
    public class TourScheduleService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public TourScheduleService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<TourSchedule>> GetAllSchedulesAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.TourSchedules
                .Include(ts => ts.Tour)
                .ToListAsync();
        }

        public async Task<List<TourSchedule>> GetUpcomingSchedulesAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.TourSchedules
                .Include(ts => ts.Tour)
                .Where(ts => ts.StartDateTime >= DateTime.Now)
                .OrderBy(ts => ts.StartDateTime)
                .ToListAsync();
        }

        public async Task<List<TourSchedule>> GetNextTwoWeeksOfSchedulesAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.TourSchedules
                .Include(ts => ts.Tour)
                .Where(ts => ts.StartDateTime >= DateTime.Now && ts.StartDateTime <= DateTime.Now.AddDays(14))
                .OrderBy(ts => ts.StartDateTime)
                .ToListAsync();
        }

        public async Task<List<TourSchedule>> GetSchedulesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.TourSchedules
                .Include(ts => ts.Tour)
                .Where(ts => ts.StartDateTime >= startDate && ts.StartDateTime <= endDate)
                .OrderBy(ts => ts.StartDateTime)
                .ToListAsync();
        }

        public async Task<List<TourSchedule>> GetSchedulesForTourAsync(int tourId)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.TourSchedules
                .Where(ts => ts.TourId == tourId)
                .OrderBy(ts => ts.StartDateTime)
                .ToListAsync();
        }

        public async Task<TourSchedule> GetScheduleByIdAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.TourSchedules
                .Include(ts => ts.Tour)
                .FirstOrDefaultAsync(ts => ts.Id == id);
        }

        public async Task<TourSchedule> CreateScheduleAsync(TourSchedule schedule)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            if (schedule.Id != 0)
            {
                schedule.Id = 0;
            }
            schedule.Tour = null;
            context.TourSchedules.Add(schedule);
            await context.SaveChangesAsync();
            return schedule;
        }

        public async Task UpdateScheduleAsync(TourSchedule schedule)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            context.TourSchedules.Update(schedule);
            await context.SaveChangesAsync();
        }

        public async Task DeleteScheduleAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var schedule = await context.TourSchedules.FindAsync(id);
            if (schedule != null)
            {
                context.TourSchedules.Remove(schedule);
                await context.SaveChangesAsync();
            }
        }
    }
}