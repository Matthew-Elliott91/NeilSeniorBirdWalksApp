using NeilSeniorBirdWalks.Data;
using NeilSeniorBirdWalks.Models;
using Microsoft.EntityFrameworkCore;

namespace NeilSeniorBirdWalks.Services
{
    public class CustomerService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public CustomerService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Customers
                .Include(c => c.Address)
                .Include(c => c.User)
                .OrderBy(c => c.LastName)
                .ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Customers
                .Include(c => c.Address)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer?> GetCustomerByUserIdAsync(string userId)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Customers
                .Include(c => c.Address)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            context.Customers.Update(customer);
            await context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var customer = await context.Customers.FindAsync(id);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Booking>> GetBookingsByCustomerIdAsync(int customerId)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var customer = await context.Customers
                .FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null || string.IsNullOrEmpty(customer.UserId))
            {
                return new List<Booking>();
            }

            return await context.Bookings
                .Include(b => b.TourSchedule)
                .Where(b => b.UserId == customer.UserId)
                .ToListAsync();
        }
    }
}
