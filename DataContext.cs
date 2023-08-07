using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;


namespace Hotel
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<Visitor> Visitors { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<User> Users { get; set; }
        
    }
}

/*  public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DataContext() { Database.EnsureCreated(); }  
        public DbSet<Book> Books { get; set; } = null!;*/