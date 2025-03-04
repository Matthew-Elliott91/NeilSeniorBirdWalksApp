using Microsoft.EntityFrameworkCore;
using NeilSeniorBirdWalks.Data;
using NeilSeniorBirdWalks.Models;

namespace NeilSeniorBirdWalks.Services
{
    public class BlogService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public BlogService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<BlogPost>> GetAllBlogPostsAsync()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.BlogPosts.ToListAsync();
        }
        public async Task<BlogPost?> GetBlogPostBySlugAsync(string slug)
        {
            if (string.IsNullOrEmpty(slug))
                return null;

            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.BlogPosts
                .FirstOrDefaultAsync(b => b.Slug.ToLower() == slug.ToLower());
        }

        public async Task<BlogPost?> GetBlogPostByIdAsync(int id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.BlogPosts.FindAsync(id);
        }

        public async Task<int> CreateBlogPostAsync(BlogPost blogPost)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            if (string.IsNullOrEmpty(blogPost.Slug))
            {
                // Generate slug from title if not provided
                blogPost.Slug = GenerateSlug(blogPost.Title);
            }

            context.BlogPosts.Add(blogPost);
            await context.SaveChangesAsync();

            return blogPost.Id;
        }

        public async Task UpdateBlogPostAsync(BlogPost blogPost)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            context.BlogPosts.Update(blogPost);
            await context.SaveChangesAsync();
        }

        public async Task DeleteBlogPostAsync(int id)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            var blogPost = await context.BlogPosts.FindAsync(id);

            if (blogPost != null)
            {
                context.BlogPosts.Remove(blogPost);
                await context.SaveChangesAsync();
            }
        }

        // Generate slug from title
        private string GenerateSlug(string title)
        {
            if (string.IsNullOrEmpty(title))
                return string.Empty;

          
            var slug = System.Text.RegularExpressions.Regex.Replace(title.ToLower(), @"[^a-z0-9\s-]", "");
            
            slug = System.Text.RegularExpressions.Regex.Replace(slug, @"\s+", "-");
           
            slug = System.Text.RegularExpressions.Regex.Replace(slug, @"-+", "-");
            
            slug = slug.Trim('-');

            return slug;
        }
    }
}
