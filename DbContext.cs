using EquipmentRepair.Models;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRepair;

internal class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(@"Server=(localdb)\user;Database=DbEquipmentRepair;Trusted_Connection=True;");
  }

  public DbSet<Client> Clients { get; set; }
  public DbSet<Performer> Performers { get; set; }
  public DbSet<Application> Applications { get; set; }
}

