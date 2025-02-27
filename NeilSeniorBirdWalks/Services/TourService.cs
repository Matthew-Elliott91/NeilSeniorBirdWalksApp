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

        public async Task<Tour> GetTourDetailsAsync(string location, string season)
        {
            if (string.IsNullOrEmpty(location) || string.IsNullOrEmpty(season))
                return null;

            await using var context = await _contextFactory.CreateDbContextAsync();

            var tour = await context.Tours
                .Include(t => t.Location)
                .Include(t => t.Season)
                .Include(t => t.TourBirds)
                .ThenInclude(tb => tb.Bird)
                .FirstOrDefaultAsync(t =>
                    t.Location.LocationCode.ToLower() == location.ToLower() &&
                    t.Season.SeasonCode.ToLower() == season.ToLower());

            return tour;
        }

        public async Task<List<Tour>> GetTourPricingAsync()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Tours
                .Include (t => t.Location)
                .Include(t => t.Season)
                .Where(t => t.Price.HasValue)
                .ToListAsync();
        }

        public async Task<List<Location>> GetLocationsAsync()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Locations.ToListAsync();
        }

        public async Task<Location> GetLocationByCodeAsync(string locationCode)
        {
            if (string.IsNullOrEmpty(locationCode))
                return null;

            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Locations
                .FirstOrDefaultAsync(l => l.LocationCode.ToLower() == locationCode.ToLower());
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
