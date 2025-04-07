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

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.TourSchedule)
                .ThenInclude(ts => ts.Tour)
                .Include(b => b.User)
                .OrderByDescending(b => b.TourSchedule.StartDateTime)
                .ToListAsync();
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
                
                var tourSchedule = await _context.TourSchedules.FindAsync(booking.TourScheduleId);

                if (tourSchedule == null)
                {
                    throw new Exception("Tour schedule not found");
                }

               
                if (!tourSchedule.AvailableSpots.HasValue || tourSchedule.AvailableSpots < booking.NumberOfParticipants)
                {
                    throw new Exception("Not enough available spots");
                }

                
                tourSchedule.AvailableSpots -= booking.NumberOfParticipants;
                _context.TourSchedules.Update(tourSchedule);

              
                _context.Bookings.Add(booking);

                await _context.SaveChangesAsync();

               
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
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                
                var tourSchedule = await _context.TourSchedules.FindAsync(booking.TourScheduleId);

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
                _context.TourSchedules.Update(tourSchedule);

               
                _context.Bookings.Update(booking);

                
                await _context.SaveChangesAsync();

              
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
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                
                var booking = await _context.Bookings
                    .Include(b => b.TourSchedule)
                    .FirstOrDefaultAsync(b => b.Id == bookingId);

                if (booking == null)
                {
                    throw new Exception("Booking not found");
                }

                
                if (booking.TourSchedule != null)
                {
                    booking.TourSchedule.AvailableSpots += booking.NumberOfParticipants;
                    _context.TourSchedules.Update(booking.TourSchedule);
                }

              
                _context.Bookings.Remove(booking);

                await _context.SaveChangesAsync();

                
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
            return await _context.Bookings
                .AnyAsync(b => b.UserId == userId && b.TourScheduleId == tourScheduleId);
        }
    }
}
