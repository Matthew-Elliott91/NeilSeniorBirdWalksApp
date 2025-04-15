using Microsoft.EntityFrameworkCore;
using NeilSeniorBirdWalks.Models;
using NeilSeniorBirdWalks.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeilSeniorBirdWalks.Services
{
    public class HeaderImageSettingsService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public HeaderImageSettingsService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<HeaderImageSettings> GetHeaderSettingsAsync(string pageIdentifier = "home")
        {
            using var context = await _contextFactory.CreateDbContextAsync();

            var settings = await context.HeaderImageSettings
                .FirstOrDefaultAsync(s => s.PageIdentifier == pageIdentifier);

            if (settings == null)
            {
                // If no settings exist for this page, create default ones
                settings = new HeaderImageSettings
                {
                    PageIdentifier = pageIdentifier
                };

                context.HeaderImageSettings.Add(settings);
                await context.SaveChangesAsync();
            }

            return settings;
        }

        public async Task<List<HeaderImageSettings>> GetAllHeaderSettingsAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.HeaderImageSettings.ToListAsync();
        }

        public async Task UpdateHeaderSettingsAsync(HeaderImageSettings settings)
        {
            using var context = await _contextFactory.CreateDbContextAsync();

            var existingSettings = await context.HeaderImageSettings
                .FirstOrDefaultAsync(s => s.PageIdentifier == settings.PageIdentifier);

            if (existingSettings == null)
            {
                context.HeaderImageSettings.Add(settings);
            }
            else
            {
                existingSettings.Title = settings.Title;
                existingSettings.Subtitle = settings.Subtitle;
                existingSettings.BackgroundImageUrl = settings.BackgroundImageUrl;
            }

            await context.SaveChangesAsync();
        }
    }
}
