using Microsoft.EntityFrameworkCore;
using NeilSeniorBirdWalks.Data;
using NeilSeniorBirdWalks.Models;

namespace NeilSeniorBirdWalks.Services
{
    public interface IContactService
    {
        Task<bool> SubmitContactFormAsync(ContactFormModel submittedContactForm);
        Task<List<ContactFormModel>> GetAllContactFormsAsync();
        Task<bool> UpdateContactFormReadStatusAsync(int id, bool isRead);
        Task<bool> DeleteContactFormAsync(int id);
        Task<IEnumerable<ContactFormModel>> GetUnreadMessagesAsync();
    }

    public class ContactService : IContactService
    {
        private readonly ILogger<ContactService> _logger;
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public ContactService(ILogger<ContactService> logger, IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _logger = logger;
            _contextFactory = contextFactory;
        }

        public async Task<bool> SubmitContactFormAsync(ContactFormModel contact)
        {
            try
            {
                using var context = await _contextFactory.CreateDbContextAsync();
                context.ContactForms.Add(contact);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error submitting contact form");
                return false;
            }
        }

        public async Task<List<ContactFormModel>> GetAllContactFormsAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.ContactForms.ToListAsync();
        }

        public async Task<bool> UpdateContactFormReadStatusAsync(int id, bool isRead)
        {
            try
            {
                using var context = await _contextFactory.CreateDbContextAsync();
                var contactForm = await context.ContactForms.FindAsync(id);
                if (contactForm == null)
                    return false;
                contactForm.IsRead = isRead;
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating contact form read status");
                return false;
            }
        }

        public async Task<bool> DeleteContactFormAsync(int id)
        {
            try
            {
                using var context = await _contextFactory.CreateDbContextAsync();
                var contactForm = await context.ContactForms.FindAsync(id);
                if (contactForm == null)
                    return false;
                context.ContactForms.Remove(contactForm);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting contact form");
                return false;
            }
        }

        public async Task<IEnumerable<ContactFormModel>> GetUnreadMessagesAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var unreadMessages = await context.ContactForms.Where(x => x.IsRead == false).ToListAsync();
            return unreadMessages;
        }
    }
}
