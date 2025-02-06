using EquipmentRepairDomain.EntityFramework.Models;
using EquipmentRepairDomain.Repositories.Interfaces;

namespace EquipmentRepairDomain.Services;

public class TechnicianService(IRepository<Technician> technicianRepository)
{
  /// <summary>
  ///     Логика добавления техника
  /// </summary>
  /// <param name="technician"></param>
  public async Task AddTechnicianAsync(Technician technician)
  {
    await technicianRepository.AddAsync(technician);
  }

  /// <summary>
  ///     Логика получения всех техников
  /// </summary>
  /// <returns></returns>
  public Task<IEnumerable<Technician>> GetAllTechniciansAsync()
  {
    return technicianRepository.GetAllAsync();
  }

  /// <summary>
  ///     Логика обновления техника
  /// </summary>
  /// <param name="updatableTechnician"></param>
  public async Task UpdateTechnicianAsync(Technician updatableTechnician)
  {
    await technicianRepository.UpdateAsync(updatableTechnician);
  }

  /// <summary>
  ///     Логика удаления техника
  /// </summary>
  /// <param name="id"></param>
  public async Task DeleteTechnicianAsync(int id)
  {
    await technicianRepository.DeleteAsync(id);
  }
}