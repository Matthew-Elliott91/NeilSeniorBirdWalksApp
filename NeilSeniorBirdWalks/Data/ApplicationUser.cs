using Microsoft.AspNetCore.Identity;
using NeilSeniorBirdWalks.Models;
namespace NeilSeniorBirdWalks.Data;

public class ApplicationUser : IdentityUser
{
    public virtual Customer? Customer { get; set; }
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
