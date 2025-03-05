using Microsoft.EntityFrameworkCore;
using NeilSeniorBirdWalks.Data;
using NeilSeniorBirdWalks.Models;

namespace NeilSeniorBirdWalks.Services
{
    public interface IContactService
    {
        Task<bool> SubmitContactFormAsync(ContactFormModel submittedContactForm);
        Task<List<ContactFormModel>> GetAllContactFormsAsync();
    }
    public class ContactService : IContactService
    {
        private readonly ILogger<ContactService> _logger;
        private readonly ApplicationDbContext _context;

        public ContactService(ILogger<ContactService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> SubmitContactFormAsync(ContactFormModel contact)
        {
            try
            {
                _context.ContactForms.Add(contact);
                await _context.SaveChangesAsync();
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
            return await _context.ContactForms.ToListAsync();
        }
    }
}
