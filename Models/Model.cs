namespace EquipmentRepair.Models;

public class Admin
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Phone { get; set; }
  public string Login { get; set; }
  public string Password { get; set; }
}

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
  public int NubmerApplication { get; set; }
  public string AddDate { get; set; }
  public string TypeEquipment {  get; set; }
  public string ModelEquipment { get; set; }
  public string FaultType { get; set; }
  public string DescriptionFault { get; set; }
  public string NameClient { get; set; }
  public string Phone { get; set; }
  public string Status { get; set; }
}