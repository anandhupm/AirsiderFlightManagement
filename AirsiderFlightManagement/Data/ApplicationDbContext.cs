using AirsiderFlightManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AirsiderFlightManagement.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightBooking> FlightBookings { get; set; }
        public DbSet<FlightSchedule> FlightSchedules { get; set;}


    }
    

}
