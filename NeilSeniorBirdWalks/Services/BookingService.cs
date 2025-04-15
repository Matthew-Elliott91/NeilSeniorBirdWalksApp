using NeilSeniorBirdWalks.Data;
using NeilSeniorBirdWalks.Models;
using Microsoft.EntityFrameworkCore;

namespace NeilSeniorBirdWalks.Services
{
    public class BookingService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public BookingService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Bookings
                .Include(b => b.TourSchedule)
                .ThenInclude(ts => ts.Tour)
                .Include(b => b.User)
                .OrderByDescending(b => b.TourSchedule.StartDateTime)
                .ToListAsync();
        }

        public async Task<List<Booking>> GetBookingsByUserIdAsync(string userId)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.TourSchedule)
                .ThenInclude(ts => ts.Tour)
                .OrderBy(b => b.TourSchedule.StartDateTime)
                .ToListAsync();
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var tourSchedule = await context.TourSchedules.FindAsync(booking.TourScheduleId);

                if (tourSchedule == null)
                {
                    throw new Exception("Tour schedule not found");
                }

                if (!tourSchedule.AvailableSpots.HasValue || tourSchedule.AvailableSpots < booking.NumberOfParticipants)
                {
                    throw new Exception("Not enough available spots");
                }

                tourSchedule.AvailableSpots -= booking.NumberOfParticipants;
                context.TourSchedules.Update(tourSchedule);

                context.Bookings.Add(booking);

                await context.SaveChangesAsync();

                await transaction.CommitAsync();

                return booking;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<Booking> UpdateBookingAsync(Booking booking, int originalParticipantCount)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var tourSchedule = await context.TourSchedules.FindAsync(booking.TourScheduleId);

                if (tourSchedule == null)
                {
                    throw new Exception("Tour schedule not found");
                }

                int participantDifference = booking.NumberOfParticipants - originalParticipantCount;

                if (participantDifference > 0 &&
                    (tourSchedule.AvailableSpots == null || tourSchedule.AvailableSpots < participantDifference))
                {
                    throw new Exception("Not enough available spots for this update");
                }

                tourSchedule.AvailableSpots -= participantDifference;
                context.TourSchedules.Update(tourSchedule);

                context.Bookings.Update(booking);

                await context.SaveChangesAsync();

                await transaction.CommitAsync();

                return booking;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task DeleteBookingAsync(int bookingId)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var booking = await context.Bookings
                    .Include(b => b.TourSchedule)
                    .FirstOrDefaultAsync(b => b.Id == bookingId);

                if (booking == null)
                {
                    throw new Exception("Booking not found");
                }

                if (booking.TourSchedule != null)
                {
                    booking.TourSchedule.AvailableSpots += booking.NumberOfParticipants;
                    context.TourSchedules.Update(booking.TourSchedule);
                }

                context.Bookings.Remove(booking);

                await context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> UserHasBookingAsync(string userId, int tourScheduleId)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Bookings
                .AnyAsync(b => b.UserId == userId && b.TourScheduleId == tourScheduleId);
        }
    }
}
