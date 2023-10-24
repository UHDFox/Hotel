using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<Visitor> Visitors { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
}
