
using Microsoft.EntityFrameworkCore;
using NeilSeniorBirdWalks.Data;
using NeilSeniorBirdWalks.Models;
using System.Threading.Tasks;

namespace NeilSeniorBirdWalks.Services
{
    public class TourService
    {
        private readonly ApplicationDbContext _context;

        public TourService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tour> GetTourDetailsAsync(string location, string season)
        {
            
            var tour = await _context.Tours
                .Include(t => t.Location)
                .Include(t => t.Season)
                .Include(t => t.TourBirds)
                .ThenInclude(tb => tb.Bird)
                .FirstOrDefaultAsync(t =>
                    t.Location.LocationCode.ToLower() == location.ToLower() &&
                    t.Season.SeasonCode.ToLower() == season.ToLower());

            return tour; // Returns null if no match found
        }
    }
}