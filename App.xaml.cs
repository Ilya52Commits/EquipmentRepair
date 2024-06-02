using EquipmentRepair.Models;
using System.Windows;
using System.IO;

namespace EquipmentRepair;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
  private readonly DbContext _dbContext = new();

  /// <summary>
  /// Метод добавления главного админа
  /// </summary>
  private void AddTheMainAdmin()
  {
    var isThereMainAdmin = _dbContext.Admins.FirstOrDefault(admin => admin.Name == "Admin"
                                                                    && admin.Login == "Admin"
                                                                    && admin.Password == "Admin"
                                                                    && admin.Phone == "Admin");

    if (isThereMainAdmin != null) return;
    
    var newMainAdmin = new Admin
    {
      Name = "Admin",
      Login = "Admin",
      Password = "Admin",
      Phone = "Admin",
    };

    _dbContext.Admins.Add(newMainAdmin);
    _dbContext.SaveChanges();
  }

  /// <summary>ы
  /// Метод добавления первых клиентов
  /// </summary>
  private void AddTheFirstsUsers()
  {
    var hasContentClients = _dbContext.Clients.Any();
    var hasContentManagers = _dbContext.Managers.Any();
    var hasContentTechnician = _dbContext.Technicians.Any();
    var hasContentOperator = _dbContext.Operators.Any();

    if (!hasContentClients)
    {
      var fileForFirstUsers = File.ReadAllText(@"import/inputDataUsers.txt");

      var splitFile = fileForFirstUsers.Split('\n');

      foreach (var line in splitFile)
      {
        var splitLine = line.Split(';');

        try
        {
          _ = int.Parse(splitLine[0]);
        }
        catch
        {
          continue;
        }

        if (splitLine[5].Trim() != "Заказчик") continue;
        var newClient = new Client
        {
          Id = int.Parse(splitLine[0].Trim()),
          Name = splitLine[1].Trim(),
          Phone = splitLine[2].Trim(),
          Login = splitLine[3].Trim(),
          Password = splitLine[4].Trim(),
        };

        _dbContext.Clients.Add(newClient);
        _dbContext.SaveChanges();
      }
    }

    if (!hasContentManagers)
    {
      var fileForFirstUsers = File.ReadAllText(@"import/inputDataUsers.txt");

      var splitFile = fileForFirstUsers.Split('\n');

      foreach (var line in splitFile)
      {
        var splitLine = line.Split(';');

        try
        {
          _ = int.Parse(splitLine[0]);
        }
        catch
        {
          continue;
        }

        if (splitLine[5].Trim() != "Менеджер") continue;
        var newManager = new Manager
        {
          Id = int.Parse(splitLine[0].Trim()),
          Name = splitLine[1].Trim(),
          Phone = splitLine[2].Trim(),
          Login = splitLine[3].Trim(),
          Password = splitLine[4].Trim(),
        };

        _dbContext.Managers.Add(newManager);
        _dbContext.SaveChanges();
      }
    }

    if (!hasContentTechnician)
    {
      var fileForFirstUsers = File.ReadAllText(@"import/inputDataUsers.txt");

      var splitFile = fileForFirstUsers.Split('\n');

      foreach (var line in splitFile)
      {
        var splitLine = line.Split(';');

        try
        {
          _ = int.Parse(splitLine[0]);
        }
        catch
        {
          continue;
        }

        if (splitLine[5].Trim() == "Техник")
        {
          var newTechnician = new Technician
          {
            Id = int.Parse(splitLine[0].Trim()),
            Name = splitLine[1].Trim(),
            Phone = splitLine[2].Trim(),
            Login = splitLine[3].Trim(),
            Password = splitLine[4].Trim(),
          };

          _dbContext.Technicians.Add(newTechnician);
          _dbContext.SaveChanges();
        }
      }
    }

    if (hasContentOperator) return;
    {
      var fileForFirstUsers = File.ReadAllText(@"import/inputDataUsers.txt");

      var splitFile = fileForFirstUsers.Split('\n');

      foreach (var line in splitFile)
      {
        var splitLine = line.Split(';');

        try
        {
          _ = int.Parse(splitLine[0]);
        }
        catch
        {
          continue;
        }

        if (splitLine[5].Trim() != "Оператор") continue;
        var newOperator = new Operator
        {
          Id = int.Parse(splitLine[0].Trim()),
          Name = splitLine[1].Trim(),
          Phone = splitLine[2].Trim(),
          Login = splitLine[3].Trim(),
          Password = splitLine[4].Trim(),
        };

        _dbContext.Operators.Add(newOperator);
        _dbContext.SaveChanges();
      }
    }
  }

  /// <summary>
  /// Метод добавления первых заявок
  /// </summary>
  private void AddTheFirstsRequests()
  {
    var hasContentRequests = _dbContext.Requests.Any();

    if (hasContentRequests) return;
    var fileForFirstUsers = File.ReadAllText(@"import/inputDataRequests.txt");

    var splitFile = fileForFirstUsers.Split('\n');

    foreach (var line in splitFile)
    {
      var splitLine = line.Split(';');

      try
      {
        _ = int.Parse(splitLine[0]);
      }
      catch
      {
        continue;
      }

      try
      {
        _ = int.Parse(splitLine[8]);
      }
      catch
      {
        var newReq = new Request
        {
          Id = int.Parse(splitLine[0]),
          StartDate = splitLine[1],
          TypeEquipment = splitLine[2],
          ModelEquipment = splitLine[3],
          DescriptionFault = splitLine[4],
          Status = splitLine[5],
          CompletionDate = splitLine[6],
          ClientId = int.Parse(splitLine[9]),
        };

        _dbContext.Requests.Add(newReq);
        _dbContext.SaveChanges();

        continue;
      }

      var newRequest = new Request
      {
        Id = int.Parse(splitLine[0]),
        StartDate = splitLine[1],
        TypeEquipment = splitLine[2],
        ModelEquipment = splitLine[3],
        DescriptionFault = splitLine[4],
        Status = splitLine[5],
        CompletionDate = splitLine[6],
        RepairParts = null,
        MasterId = int.Parse(splitLine[8]),
        ClientId = int.Parse(splitLine[9]),
      };

      _dbContext.Requests.Add(newRequest);
      _dbContext.SaveChanges();
    }
  }


  /// <summary>
  /// Метод для выполнения комманд во время запуска программы
  /// </summary>
  /// <param name="e"></param>
  protected override void OnStartup(StartupEventArgs e)
  {
    AddTheMainAdmin();
    AddTheFirstsUsers();
    AddTheFirstsRequests();

    base.OnStartup(e);
  }
}
