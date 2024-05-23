namespace EquipmentRepair.Models;

public class Client
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Phone { get; set; }
  public string Login { get; set; }
  public string Password { get; set; }
}

public class Meneger
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Phone { get; set; }
  public string Login { get; set; }
  public string Password { get; set; }
}

public class Technician
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Phone { get; set; }
  public string Login { get; set; }
  public string Password { get; set; }
}

public class Operator
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Phone { get; set; }
  public string Login { get; set; }
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