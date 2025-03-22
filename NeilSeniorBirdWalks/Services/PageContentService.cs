using Microsoft.EntityFrameworkCore;
using NeilSeniorBirdWalks.Data;
using NeilSeniorBirdWalks.Models;

namespace NeilSeniorBirdWalks.Services
{
    public class PageContentService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public PageContentService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<PageContent> GetPageContentAsync(string pageType)
        {
            if (string.IsNullOrEmpty(pageType))
                return null;
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.PageContents
                .FirstOrDefaultAsync(p => p.PageType == pageType && p.IsPublished);

        }

        public async Task<List<PageContent>> GetAllPageContentAsync()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.PageContents.ToListAsync();
        }

        public async Task<bool> SavePageContentAsync(PageContent pageContent)
        {
            if (pageContent == null)
                return false;
            await using var context = await _contextFactory.CreateDbContextAsync();
            if (pageContent.Id == 0)
            {
                context.PageContents.Add(pageContent);
            }
            else
            {
                context.PageContents.Update(pageContent);
            }
            return await context.SaveChangesAsync() > 0;

        }
        public async Task<bool> DeletePageContentAsync(int id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var pageContent = await context.PageContents.FindAsync(id);

            if (pageContent == null)
                return false;

            context.PageContents.Remove(pageContent);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task UpdatePageContentAsync(PageContent updatedContent)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var content = await context.PageContents.FindAsync(updatedContent.Id);

            if (content == null)
            {
                throw new KeyNotFoundException($"Page content with ID {updatedContent.Id} not found.");
            }

            // Update properties
            content.Title = updatedContent.Title;
            content.Subtitle = updatedContent.Subtitle;
            content.MainContent = updatedContent.MainContent;
            content.MainContentImage = updatedContent.MainContentImage;
            content.SecondaryContent = updatedContent.SecondaryContent;
            content.SecondaryContentImage = updatedContent.SecondaryContentImage;
            content.TertiaryContent = updatedContent.TertiaryContent;
            content.TertiaryContentImage = updatedContent.TertiaryContentImage;
            content.IsPublished = updatedContent.IsPublished;

            await context.SaveChangesAsync();
        }
    }
}
