using Bit.FindBit.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bit.FindBit.DataAccess.DbAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PhoneNumber>()
            .Property(p => p.Type)
            .HasConversion<string>(); 
    }
}