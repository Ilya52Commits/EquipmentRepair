namespace EquipmentRepairDomain.EntityFramework.InterfacesModel;

public interface ICurrentUser
{
  public int Id { get; init; }
  public string? Name { get; init; }
  public string? Phone { get; init; }
  public string? Login { get; init; }
  public string? Password { get; init; }
}