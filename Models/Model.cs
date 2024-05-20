namespace EquipmentRepair.Models;

public class Client
{
  public int Id { get; set; }
  public string Login { get; set; }
  public string Password { get; set; }
  public string Email { get; set; }
}

public class Performer
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Email { get; set; }
  public string Password { get; set; }
}

public class Application
{
  public int Id { get; set; }
  public string AddDate { get; set; }
  public string Equipment {  get; set; }
  public string FaultType { get; set; }
  public string DescriptionFault { get; set; }
  public int IdClient { get; set; }
  public string Status { get; set; }
}