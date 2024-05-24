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
    bool hasContentClients = _dbContext.Clients.Any();
    bool hasContentManagers = _dbContext.Menegers.Any();
    bool hasContentTechnician = _dbContext.Technicians.Any();
    bool hasContentOperator = _dbContext.Operators.Any();

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
            Name = splitedLine[1],
            Phone = splitedLine[2],
            Login = splitedLine[3],
            Password = splitedLine[4],
          };

          _dbContext.Clients.Add(newClient);
          _dbContext.SaveChanges();
        }
      }
    }

    else if (!hasContentManagers)
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
            Name = splitedLine[1],
            Phone = splitedLine[2],
            Login = splitedLine[3],
            Password = splitedLine[4],
          };

          _dbContext.Menegers.Add(newMeneger);
          _dbContext.SaveChanges();
        }
      }
    }

    else if (!hasContentTechnician)
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
            Name = splitedLine[1],
            Phone = splitedLine[2],
            Login = splitedLine[3],
            Password = splitedLine[4],
          };

          _dbContext.Technicians.Add(newTechnician);
          _dbContext.SaveChanges();
        }
      }
    }

    else if (!hasContentOperator)
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
            Name = splitedLine[1],
            Phone = splitedLine[2],
            Login = splitedLine[3],
            Password = splitedLine[4],
          };

          _dbContext.Operators.Add(newOperator);
          _dbContext.SaveChanges();
        }
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

    base.OnStartup(e);
  }
}
