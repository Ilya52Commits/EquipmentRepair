using EquipmentRepair.Models;
using System.Windows;
using System.IO;

namespace EquipmentRepair;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
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

    if (isThereMainAdmin == null)
    {
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
  }

  /// <summary>ы
  /// Метод добавления первых клиентов
  /// </summary>
  private void AddTheFirstsUsers()
  {
    var hasContentClients = _dbContext.Clients.Any();
    var hasContentManagers = _dbContext.Menegers.Any();
    var hasContentTechnician = _dbContext.Technicians.Any();
    var hasContentOperator = _dbContext.Operators.Any();

    if (!hasContentClients)
    {
      var fileForFirstUsers = File.ReadAllText(@"import/inputDataUsers.txt");

      var splitedFile = fileForFirstUsers.Split('\n');

      foreach (var line in splitedFile)
      {
        var splitedLine = line.Split(';');

        try
        {
          int.Parse(splitedLine[0]);
        }
        catch
        {
          continue;
        }

        if (splitedLine[5].Trim() == "Заказчик")
        {
          var newClient = new Client
          {
            Id = int.Parse(splitedLine[0].Trim()),
            Name = splitedLine[1].Trim(),
            Phone = splitedLine[2].Trim(),
            Login = splitedLine[3].Trim(),
            Password = splitedLine[4].Trim(),
          };

          _dbContext.Clients.Add(newClient);
          _dbContext.SaveChanges();
        }
      }
    }

    if (!hasContentManagers)
    {
      var fileForFirstUsers = File.ReadAllText(@"import/inputDataUsers.txt");

      var splitedFile = fileForFirstUsers.Split('\n');

      foreach (var line in splitedFile)
      {
        var splitedLine = line.Split(';');

        try
        {
          int.Parse(splitedLine[0]);
        }
        catch
        {
          continue;
        }

        if (splitedLine[5].Trim() == "Менеджер")
        {
          var newMeneger = new Meneger
          {
            Id = int.Parse(splitedLine[0].Trim()),
            Name = splitedLine[1].Trim(),
            Phone = splitedLine[2].Trim(),
            Login = splitedLine[3].Trim(),
            Password = splitedLine[4].Trim(),
          };

          _dbContext.Menegers.Add(newMeneger);
          _dbContext.SaveChanges();
        }
      }
    }

    if (!hasContentTechnician)
    {
      var fileForFirstUsers = File.ReadAllText(@"import/inputDataUsers.txt");

      var splitedFile = fileForFirstUsers.Split('\n');

      foreach (var line in splitedFile)
      {
        var splitedLine = line.Split(';');

        try
        {
          int.Parse(splitedLine[0]);
        }
        catch
        {
          continue;
        }

        if (splitedLine[5].Trim() == "Техник")
        {
          var newTechnician = new Technician
          {
            Id = int.Parse(splitedLine[0].Trim()),
            Name = splitedLine[1].Trim(),
            Phone = splitedLine[2].Trim(),
            Login = splitedLine[3].Trim(),
            Password = splitedLine[4].Trim(),
          };

          _dbContext.Technicians.Add(newTechnician);
          _dbContext.SaveChanges();
        }
      }
    }

    if (!hasContentOperator)
    {
      var fileForFirstUsers = File.ReadAllText(@"import/inputDataUsers.txt");

      var splitedFile = fileForFirstUsers.Split('\n');

      foreach (var line in splitedFile)
      {
        var splitedLine = line.Split(';');

        try
        {
          int.Parse(splitedLine[0]);
        }
        catch
        {
          continue;
        }

        if (splitedLine[5].Trim() == "Оператор")
        {
          var newOperator = new Operator
          {
            Id = int.Parse(splitedLine[0].Trim()),
            Name = splitedLine[1].Trim(),
            Phone = splitedLine[2].Trim(),
            Login = splitedLine[3].Trim(),
            Password = splitedLine[4].Trim(),
          };

          _dbContext.Operators.Add(newOperator);
          _dbContext.SaveChanges();
        }
      }
    }
  }

  /// <summary>
  /// Метод добавления первых заявок
  /// </summary>
  private void AddTheFirstsRequests()
  {
    bool hasContentRequests = _dbContext.Requests.Any();

    if (!hasContentRequests)
    {
      var fileForFirstUsers = File.ReadAllText(@"import/inputDataRequests.txt");

      var splitedFile = fileForFirstUsers.Split('\n');

      foreach (var line in splitedFile)
      {
        var splitedLine = line.Split(';');

        try
        {
          int.Parse(splitedLine[0]);
        }
        catch
        {
          continue;
        }

        try
        {
          int.Parse(splitedLine[8]);
        }
        catch
        {
          var newReq = new Request
          {
            Id = int.Parse(splitedLine[0]),
            StartDate = splitedLine[1],
            TypeEquipment = splitedLine[2],
            ModelEquipment = splitedLine[3],
            DescriptionFault = splitedLine[4],
            Status = splitedLine[5],
            CompletionDate = splitedLine[6],
            ClientId = int.Parse(splitedLine[9]),
          };

          _dbContext.Requests.Add(newReq);
          _dbContext.SaveChanges();

          continue;
        }

        var newRequest = new Request
        {
          Id = int.Parse(splitedLine[0]),
          StartDate = splitedLine[1],
          TypeEquipment = splitedLine[2],
          ModelEquipment = splitedLine[3],
          DescriptionFault = splitedLine[4],
          Status = splitedLine[5],
          CompletionDate = splitedLine[6],
          RepairParts = null,
          MasterId = int.Parse(splitedLine[8]),
          ClientId = int.Parse(splitedLine[9]),
        };

        _dbContext.Requests.Add(newRequest);
        _dbContext.SaveChanges();
      }
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
