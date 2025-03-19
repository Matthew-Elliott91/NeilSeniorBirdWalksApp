using NeilSeniorBirdWalks.Data;
using NeilSeniorBirdWalks.Models;
using Microsoft.EntityFrameworkCore;

namespace NeilSeniorBirdWalks.Services
{
    public class BookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetBookingsByUserIdAsync(string userId) 
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.TourSchedule)
                .ThenInclude(ts => ts.Tour)
                .OrderBy(b => b.TourSchedule.StartDateTime)
                .ToListAsync();
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> UpdateBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task DeleteBookingAsync(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> UserHasBookingAsync(string userId, int tourScheduleId)
        {
            return await _context.Bookings
                .AnyAsync(b => b.UserId == userId && b.TourScheduleId == tourScheduleId);
        }
    }
}
