using EquipmentRepairDomain.Data;
using EquipmentRepairDomain.EntityFramework.Models;
using EquipmentRepairDomain.Exceptions;
using EquipmentRepairDomain.Repositories.Interfaces;

namespace EquipmentRepairDomain.Services;

public class ClientService(IRepository<Client> clientRepository)
{
  private const string LoginCanNotBeEmptyValidationText = "Логин не может быть пустым.";
  private const string LoginMustBeUniqueValidationText = "Логин должен быть уникальным.";
  private const string UserValidValidationText = "Пользователь валиден.";
  private const string SomethingWentWrong = "Что-то пошло не так...";

  /// <summary>
  ///     Логика добавления клиента
  /// </summary>
  /// <param name="client"></param>
  public async Task AddClientAsync(Client client)
  {
    var isUserValid = await IsClientValid(client);

    if (!isUserValid.IsValid)
      throw new UserValidationException(isUserValid.Message ?? SomethingWentWrong);

    await clientRepository.AddAsync(client);
  }

  /// <summary>
  ///     Логика получения всех клиентов
  /// </summary>
  /// <returns></returns>
  public Task<IEnumerable<Client>> GetAllClientsAsync()
  {
    return clientRepository.GetAllAsync();
  }

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
  public async Task DeleteClientAsync(int id)
  {
    await clientRepository.DeleteAsync(id);
  }

  /// <summary>
  ///     Логика проверки валидности данных клиента
  /// </summary>
  /// <param name="client">Пользователь для проверки</param>
  /// <returns></returns>
  private async Task<ValidationResult> IsClientValid(Client client)
  {
    var result = new ValidationResult();

    if (string.IsNullOrWhiteSpace(client.Login))
    {
      result.IsValid = false;
      result.Message = LoginCanNotBeEmptyValidationText;
      return result;
    }

    // Проверка на уникальность логина
    var existingUser = (await clientRepository.GetAllAsync()).FirstOrDefault(u => u.Login == client.Login);

    if (existingUser != null)
    {
      result.IsValid = false;
      result.Message = LoginMustBeUniqueValidationText;
      return result;
    }

    // Если все проверки пройдены
    result.IsValid = true;
    result.Message = UserValidValidationText;
    return result;
  }
}