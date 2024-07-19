using Microsoft.EntityFrameworkCore;
using REngine2.model;

namespace REngine2.config;

public class REngineDbContext : DbContext
{
    public REngineDbContext(DbContextOptions<REngineDbContext> options) : base(options)
    {
    }
    
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<RTransaction> Transactions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<HotelRoom> HotelRooms { get; set; }
    
}