using EquipmentRepairDomain.EntityFramework.Models;
using EquipmentRepairDomain.Repositories.Interfaces;

namespace EquipmentRepairDomain.Services;

public class ClientService(IRepository<Client> clientRepository)
{
  /// <summary>
  ///     Логика добавления клиента
  /// </summary>
  /// <param name="client"></param>
  public async Task AddClientAsync(Client client)
  {
    await clientRepository.AddAsync(client);
  }

  /// <summary>
  ///     Логика получения всех клиентов
  /// </summary>
  /// <returns></returns>
  public Task<IEnumerable<Client>> GetAllClientsAsync() => clientRepository.GetAllAsync();
  
  /// <summary>
  ///     Логика обновления клиента
  /// </summary>
  /// <param name="updatableUser"></param>
  public async Task UpdateClientAsync(Client updatableUser)
  {
    await clientRepository.UpdateAsync(updatableUser);
  }

  /// <summary>
  ///     Логика удаления клиента
  /// </summary>
  /// <param name="id"></param>
  public async Task DeleteClientAsync(int id) => await clientRepository.DeleteAsync(id);
}