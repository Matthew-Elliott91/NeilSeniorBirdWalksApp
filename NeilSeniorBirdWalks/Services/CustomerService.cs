using NeilSeniorBirdWalks.Data;
using NeilSeniorBirdWalks.Models;
using Microsoft.EntityFrameworkCore;

namespace NeilSeniorBirdWalks.Services
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers
                .Include(c => c.Address)
                .Include(c => c.User)  
                .OrderBy(c => c.LastName)
                .ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers
                .Include(c => c.Address)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer?> GetCustomerByUserIdAsync(string userId)
        {
            return await _context.Customers
                .Include(c => c.Address)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Booking>> GetBookingsByCustomerIdAsync(int customerId)
        {
           var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null || string.IsNullOrEmpty(customer.UserId))
            {
                return new List<Booking>();
            }
            return await _context.Bookings
                .Include(b => b.TourSchedule)
                .Where(b => b.UserId == customer.UserId)
                .ToListAsync();
        }

    }
}
