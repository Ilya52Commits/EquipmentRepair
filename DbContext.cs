using EquipmentRepair.Models;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRepair;

internal class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    //_ = optionsBuilder.UseSqlServer(@"Server=DESKSTOP-13U175P\user;Database=DbEquipmentRepair;Trusted_Connection=True;");
    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DbEquipmentRepair;Username=postgres;Password=52");
  }
  
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Request>().Property(g => g.Id).UseIdentityAlwaysColumn()
      .HasIdentityOptions(startValue: 100);
    
    modelBuilder.Entity<Admin>().Property(g => g.Id).UseIdentityAlwaysColumn()
      .HasIdentityOptions(startValue: 100);
    
    modelBuilder.Entity<Client>().Property(g => g.Id).UseIdentityAlwaysColumn()
      .HasIdentityOptions(startValue: 100);
    
    modelBuilder.Entity<Meneger>().Property(g => g.Id).UseIdentityAlwaysColumn()
      .HasIdentityOptions(startValue: 100);
    
    modelBuilder.Entity<Technician>().Property(g => g.Id).UseIdentityAlwaysColumn()
      .HasIdentityOptions(startValue: 100);
      
    modelBuilder.Entity<Operator>().Property(g => g.Id).UseIdentityAlwaysColumn()
      .HasIdentityOptions(startValue: 100);
  }

  public DbSet<Admin> Admins { get; set; }
  public DbSet<Client> Clients { get; set; }
  public DbSet<Meneger> Menegers { get; set; }
  public DbSet<Technician> Technicians { get; set; }
  public DbSet<Operator> Operators { get; set; }
  public DbSet<Request> Requests { get; set; }
}

