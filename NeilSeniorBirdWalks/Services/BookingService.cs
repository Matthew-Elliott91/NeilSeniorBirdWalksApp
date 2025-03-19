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
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // First, get the latest tour schedule
                var tourSchedule = await _context.TourSchedules.FindAsync(booking.TourScheduleId);

                if (tourSchedule == null)
                {
                    throw new Exception("Tour schedule not found");
                }

                // Ensure there are enough spots available
                if (!tourSchedule.AvailableSpots.HasValue || tourSchedule.AvailableSpots < booking.NumberOfParticipants)
                {
                    throw new Exception("Not enough available spots");
                }

                // Update available spots
                tourSchedule.AvailableSpots -= booking.NumberOfParticipants;
                _context.TourSchedules.Update(tourSchedule);

                // Add the booking
                _context.Bookings.Add(booking);

                // Save all changes
                await _context.SaveChangesAsync();

                // Commit transaction
                await transaction.CommitAsync();

                return booking;
            }
            catch (Exception)
            {
                // Rollback if anything fails
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<Booking> UpdateBookingAsync(Booking booking, int originalParticipantCount)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Get current tour schedule
                var tourSchedule = await _context.TourSchedules.FindAsync(booking.TourScheduleId);

                if (tourSchedule == null)
                {
                    throw new Exception("Tour schedule not found");
                }

                // Calculate the difference in participants
                int participantDifference = booking.NumberOfParticipants - originalParticipantCount;

                // If increasing participants, check if enough spots available
                if (participantDifference > 0 &&
                    (tourSchedule.AvailableSpots == null || tourSchedule.AvailableSpots < participantDifference))
                {
                    throw new Exception("Not enough available spots for this update");
                }

                // Update available spots in tour schedule
                tourSchedule.AvailableSpots -= participantDifference;
                _context.TourSchedules.Update(tourSchedule);

                // Update the booking
                _context.Bookings.Update(booking);

                // Save all changes
                await _context.SaveChangesAsync();

                // Commit transaction
                await transaction.CommitAsync();

                return booking;
            }
            catch (Exception)
            {
                // Rollback if anything fails
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task DeleteBookingAsync(int bookingId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Get the booking with its tour schedule
                var booking = await _context.Bookings
                    .Include(b => b.TourSchedule)
                    .FirstOrDefaultAsync(b => b.Id == bookingId);

                if (booking == null)
                {
                    throw new Exception("Booking not found");
                }

                // Return spots to available count
                if (booking.TourSchedule != null)
                {
                    booking.TourSchedule.AvailableSpots += booking.NumberOfParticipants;
                    _context.TourSchedules.Update(booking.TourSchedule);
                }

                // Remove the booking
                _context.Bookings.Remove(booking);

                // Save all changes
                await _context.SaveChangesAsync();

                // Commit transaction
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                // Rollback if anything fails
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> UserHasBookingAsync(string userId, int tourScheduleId)
        {
            return await _context.Bookings
                .AnyAsync(b => b.UserId == userId && b.TourScheduleId == tourScheduleId);
        }
    }
}
