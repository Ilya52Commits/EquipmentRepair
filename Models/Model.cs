namespace EquipmentRepair.Models;

public class Admin
{
  public int Id { get; init; }
  public string? Name { get; init; }
  public string? Phone { get; init; }
  public string? Login { get; init; }
  public string? Password { get; init; }
}

public class Client
{
  public int Id { get; init; }
  public string? Name { get; init; }
  public string? Phone { get; init; }
  public string? Login { get; init; }
  public string? Password { get; init; }
}

public class Manager
{
  public int Id { get; init; }
  public string? Name { get; init; }
  public string? Phone { get; init; }
  public string? Login { get; init; }
  public string? Password { get; init; }
}

public class Technician
{
  public int Id { get; init; }
  public string? Name { get; init; }
  public string? Phone { get; init; }
  public string? Login { get; init; }
  public string? Password { get; init; }
}

public class Operator
{
  public int Id { get; init; }
  public string? Name { get; init; }
  public string? Phone { get; init; }
  public string? Login { get; init; }
  public string? Password { get; init; }
}

public class Request
{
  public int Id { get; set; }
  public string? StartDate { get; set; }
  public string? TypeEquipment { get; set; }
  public string? ModelEquipment { get; set; }
  public string? DescriptionFault { get; set; }
  public string? Status { get; set; }
  public string? CompletionDate { get; set; }
  public string? RepairParts { get; init; }
  public int? MasterId { get; set; }
  public int? ClientId { get; init; }
}