using EquipmentRepair.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRepair.EntityFramework;

internal sealed class Context : DbContext
{
  #region Объекты таблиц модели

  public DbSet<Admin> Admins { get; }
  public DbSet<Client> Clients { get; }
  public DbSet<Manager> Managers { get; }
  public DbSet<Technician> Technicians { get; }
  public DbSet<Operator> Operators { get; }
  public DbSet<Request> Requests { get; }

  #endregion

  /// <summary>
  /// Конструктор по умолчанию
  /// </summary>
  public Context() => Database.EnsureCreated();

  /// <summary>
  /// Метод для подключения к бд
  /// </summary>
  /// <param name="optionsBuilder"></param>
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
    optionsBuilder.UseLazyLoadingProxies()
      .UseSqlServer(
        @"Server=DESKTOP-34SGMAN\LOCALDB;Database=EquipmentRepairDb;Trusted_Connection=True;TrustServerCertificate=True;");

  /// <summary>
  /// Метод для наполнения бд начальными данными
  /// </summary>
  /// <param name="modelBuilder"></param>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    /* Инициализация объекта для таблицы Admin */
    var mainAdmin = new Admin { Id = 1, Name = "Admin", Login = "Admin", Password = "Admin", Phone = "Admin" };

    #region Инициализация объектов для таблицы Manager

    var firstManager = new Manager
      { Id = 1, Name = "Анатолий", Phone = "+79999999999", Login = "Anatoly", Password = "123456" };
    var secondManager = new Manager
      { Id = 2, Name = "Аркадий", Phone = "+79999999999", Login = "Arcadiy", Password = "123456" };
    var thirdManager = new Manager
      { Id = 3, Name = "Юрий", Phone = "+79999999999", Login = "Yuriy", Password = "123456" };

    #endregion

    #region Инициализация объектов для таблицы Technician

    var firstTechnician = new Technician
      { Id = 1, Name = "Анатолий", Phone = "+79999999999", Login = "Anatoly", Password = "123456" };
    var secondTechnician = new Technician
      { Id = 2, Name = "Аркадий", Phone = "+79999999999", Login = "Arcadiy", Password = "123456" };
    var thirdTechnician = new Technician
      { Id = 3, Name = "Юрий", Phone = "+79999999999", Login = "Yuriy", Password = "123456" };

    #endregion

    #region Инициализация объектов для таблицы Operator

    var firstOperator = new Operator
      { Id = 1, Name = "Анатолий", Phone = "+79999999999", Login = "Anatoly", Password = "123456" };
    var secondOperator = new Operator
      { Id = 2, Name = "Аркадий", Phone = "+79999999999", Login = "Arcadiy", Password = "123456" };
    var thirdOperator = new Operator
      { Id = 3, Name = "Юрий", Phone = "+79999999999", Login = "Yuriy", Password = "123456" };

    #endregion


    #region Инициализация объектов для таблицы Client

    var firstClient = new Client
      { Id = 1, Name = "Анатолий", Phone = "+79999999999", Login = "Anatoly", Password = "123456" };
    var secondClient = new Client
      { Id = 2, Name = "Аркадий", Phone = "+79999999999", Login = "Arcadiy", Password = "123456" };
    var thirdClient = new Client
      { Id = 3, Name = "Юрий", Phone = "+79999999999", Login = "Yuriy", Password = "123456" };

    #endregion

    #region Добавление данных в БД

    modelBuilder.Entity<Admin>().HasData(mainAdmin);
    modelBuilder.Entity<Technician>().HasData(firstTechnician, secondTechnician, thirdTechnician);
    modelBuilder.Entity<Manager>().HasData(firstManager, secondManager, thirdManager);
    modelBuilder.Entity<Operator>().HasData(firstOperator, secondOperator, thirdOperator);
    modelBuilder.Entity<Client>().HasData(firstClient, secondClient, thirdClient);

    #endregion
  }
}