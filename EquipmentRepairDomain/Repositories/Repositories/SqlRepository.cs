using EquipmentRepairDomain.EntityFramework;
using EquipmentRepairDomain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRepairDomain.Repositories.Repositories;

internal class SqlRepository<T>(Context context) : IRepository<T> where T : class
{
  private readonly DbSet<T> _dbSet = context.Set<T>();

  public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

  public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

  public async Task AddAsync(T item)
  {
    await _dbSet.AddAsync(item);
    await SaveAsync();
  }

  public async Task UpdateAsync(T item)
  {
    _dbSet.Update(item);
    await SaveAsync();
  }

  public async Task DeleteAsync(int id)
  {
    var user = await _dbSet.FindAsync(id);

    if (user == null)
      return;

    _dbSet.Remove(user);

    await context.SaveChangesAsync();
  }

  public async Task SaveAsync()
  {
    await context.SaveChangesAsync();
  }
}