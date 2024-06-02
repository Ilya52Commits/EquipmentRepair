using EquipmentRepair.Models;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRepair;

internal class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DbEquipmentRepair;Username=postgres;Password=52");
  
  public DbSet<Admin> Admins { get; }
  public DbSet<Client> Clients { get; }
  public DbSet<Manager> Managers { get; }
  public DbSet<Technician> Technicians { get; }
  public DbSet<Operator> Operators { get; }
  public DbSet<Request> Requests { get; }
}

