using EquipmentRepairDomain.EntityFramework.InterfacesModel;

namespace EquipmentRepairDomain.Services.Interfaces;

public interface ISessionService
{
  public ICurrentUser CurrentUser { get; }
  public Role CurrentRole { get; }
  public void SetCurrentUser(ICurrentUser user, string role);
}

public enum Role
{
  Admin,
  Client, 
  Technician,
  Master 
}