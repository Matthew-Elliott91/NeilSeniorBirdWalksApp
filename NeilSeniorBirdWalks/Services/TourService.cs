using Microsoft.EntityFrameworkCore;
using NeilSeniorBirdWalks.Data;
using NeilSeniorBirdWalks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeilSeniorBirdWalks.Services
{
    public class TourService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public TourService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Tour> GetTourByIdAsync(int tourId)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Tours
                .Include(t => t.TourSeasons)
                .ThenInclude(ts => ts.Season)
                .Include(t => t.TourBirds)
                .ThenInclude(tb => tb.Bird)
                .Include(t => t.TourSchedules)
                .FirstOrDefaultAsync(t => t.TourId == tourId);
        }

        public async Task<List<Tour>> GetAllToursAsync()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Tours
                .Include(t => t.TourSeasons)
                .ThenInclude(ts => ts.Season)
                .Include(t => t.TourSchedules)
                .ToListAsync();
        }

        public async Task DeleteTourAsync(int tourId)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var tour = await context.Tours.FindAsync(tourId);
            if (tour != null)
            {
                context.Tours.Remove(tour);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Season>> GetSeasonsAsync()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Seasons.ToListAsync();
        }

        public async Task<Season> GetSeasonByCodeAsync(string seasonCode)
        {
            if (string.IsNullOrEmpty(seasonCode))
                return null;

            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Seasons
                .FirstOrDefaultAsync(s => s.SeasonCode.ToLower() == seasonCode.ToLower());
        }
    }
}
