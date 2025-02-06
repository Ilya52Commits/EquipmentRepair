using EquipmentRepairDomain.Data;
using EquipmentRepairDomain.EntityFramework.InterfacesModel;
using EquipmentRepairDomain.Services.Interfaces;

namespace EquipmentRepairDomain.Services.CurrentUserServices;

public class SessionService : ISessionService
{
  public Role CurrentRole { get; private set; }
  public ICurrentUser CurrentUser { get; private set; } = null!;

  public void SetCurrentUser(ICurrentUser user, string role)
  {
    CurrentUser = user;
    CurrentRole = (Role)Enum.Parse(typeof(Role), role);
  }
}