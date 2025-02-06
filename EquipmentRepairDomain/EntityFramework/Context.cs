using EquipmentRepairDomain.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRepairDomain.EntityFramework;

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

  public Context(DbContextOptions<Context> options) : base(options) => Database.EnsureCreated();

  /// <summary>
  ///     Логика наполнения бд начальными данными
  /// </summary>
  /// <param name="modelBuilder"></param>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    /* Инициализация объекта для таблицы Admin */
    var mainAdmin = new Admin { Id = 1, Name = "Admin", Login = "Admin", Password = "Admin", Phone = "Admin" };

    #region Инициализация объектов для таблицы Manager

    var firstManager = new Manager
      { Id = 1, Name = "Анатолий", Phone = "+79999999999", Login = "AnatolyManager1", Password = "123456" };
    var secondManager = new Manager
      { Id = 2, Name = "Аркадий", Phone = "+79999999999", Login = "ArcadyManager2", Password = "123456" };
    var thirdManager = new Manager
      { Id = 3, Name = "Юрий", Phone = "+79999999999", Login = "YuriyManager3", Password = "123456" };

    #endregion

    #region Инициализация объектов для таблицы Technician

    var firstTechnician = new Technician
      { Id = 1, Name = "Анатолий", Phone = "+79999999999", Login = "AnatolyTech1", Password = "123456" };
    var secondTechnician = new Technician
      { Id = 2, Name = "Аркадий", Phone = "+79999999999", Login = "ArcadyTech2", Password = "123456" };
    var thirdTechnician = new Technician
      { Id = 3, Name = "Юрий", Phone = "+79999999999", Login = "YuriyTech3", Password = "123456" };

    #endregion

    #region Инициализация объектов для таблицы Operator

    var firstOperator = new Operator
      { Id = 1, Name = "Анатолий", Phone = "+79999999999", Login = "AnatolyOperator1", Password = "123456" };
    var secondOperator = new Operator
      { Id = 2, Name = "Аркадий", Phone = "+79999999999", Login = "ArcadyOperator2", Password = "123456" };
    var thirdOperator = new Operator
      { Id = 3, Name = "Юрий", Phone = "+79999999999", Login = "YuriyOperator3", Password = "123456" };

    #endregion


    #region Инициализация объектов для таблицы Client

    var firstClient = new Client
      { Id = 1, Name = "Анатолий", Phone = "+79999999999", Login = "AnatolyClient1", Password = "123456" };
    var secondClient = new Client
      { Id = 2, Name = "Аркадий", Phone = "+79999999999", Login = "ArcadiyClient2", Password = "123456" };
    var thirdClient = new Client
      { Id = 3, Name = "Юрий", Phone = "+79999999999", Login = "YuriyClient3", Password = "123456" };

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