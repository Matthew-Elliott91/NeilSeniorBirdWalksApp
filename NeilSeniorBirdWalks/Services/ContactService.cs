﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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

        public async Task<bool> UpdateContactFormReadStatusAsync(int id, bool isRead)
        {
            try
            {
                
                var contactForm = await _context.ContactForms.FindAsync(id);
                if (contactForm == null)
                    return false;
                contactForm.IsRead = isRead;
                await _context.SaveChangesAsync();
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
                var contactForm = await _context.ContactForms.FindAsync(id);
                if (contactForm == null)
                    return false;
                _context.ContactForms.Remove(contactForm);
                await _context.SaveChangesAsync();
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
            var unreadMessages = await _context.ContactForms.Where(x => x.IsRead == false).ToListAsync();
            return unreadMessages;
        } 

    }
}
