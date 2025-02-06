using EquipmentRepairDomain.EntityFramework.Models;
using EquipmentRepairDomain.Repositories.Interfaces;

namespace EquipmentRepairDomain.Services;

public class RequestService(IRepository<Request> requestRepository)
{
  /// <summary>
  ///     Логика добавления заявки
  /// </summary>
  /// <param name="request"></param>
  public async Task AddRequestAsync(Request request)
  {
    await requestRepository.AddAsync(request);
  }

  /// <summary>
  ///     Логика получения всех заявок
  /// </summary>
  /// <returns></returns>
  public Task<IEnumerable<Request>> GetAllRequestsAsync() => requestRepository.GetAllAsync();
  
  /// <summary>
  ///     Логика обновления заявки
  /// </summary>
  /// <param name="updatableRequest"></param>
  public async Task UpdateRequestAsync(Request updatableRequest)
  {
    await requestRepository.UpdateAsync(updatableRequest);
  }

  /// <summary>
  ///     Логика удаления заявки
  /// </summary>
  /// <param name="id"></param>
  public async Task DeleteRequestAsync(int id) => await requestRepository.DeleteAsync(id);
}