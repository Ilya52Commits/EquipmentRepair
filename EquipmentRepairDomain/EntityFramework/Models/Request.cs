namespace EquipmentRepairDomain.EntityFramework.Models;

public class Request
{
  public int Id { get; set; }
  public string? StartDate { get; set; }
  public string? TypeEquipment { get; set; }
  public string? ModelEquipment { get; set; }
  public string? DescriptionFault { get; set; }
  public string? Status { get; set; }
  public string? CompletionDate { get; set; }
  public string? RepairParts { get; set; }
  public int? MasterId { get; set; }
  public int ClientId { get; init; }
}