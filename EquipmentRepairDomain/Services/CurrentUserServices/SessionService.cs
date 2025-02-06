using EquipmentRepairDomain.EntityFramework.InterfacesModel;
using EquipmentRepairDomain.Services.Interfaces;

namespace EquipmentRepairDomain.Services.CurrentUserServices;

public class SessionService : ISessionService
{
  private ISessionService _sessionServiceImplementation;
  public Role CurrentRole { get; private set; }
  public ICurrentUser CurrentUser { get; private set; }
  public void SetCurrentUser(ICurrentUser user, string role)
  {
    CurrentUser = user;
    CurrentRole = (Role)Enum.Parse(typeof(Role), role);
  }
}