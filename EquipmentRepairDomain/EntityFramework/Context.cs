using EquipmentRepairDomain.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRepairDomain.EntityFramework;

internal sealed class Context : DbContext
{
  #region Объекты таблиц модели

  public DbSet<Client> Clients { get; }
  public DbSet<Technician> Technicians { get; }
  public DbSet<Request> Requests { get; }

  #endregion

  public Context(DbContextOptions<Context> options) : base(options)
  {
    Database.EnsureCreated();
  }

  /// <summary>
  ///     Логика наполнения бд начальными данными
  /// </summary>
  /// <param name="modelBuilder"></param>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    #region Инициализация объектов для таблицы Technician

    var firstTechnician = new Technician
      { Id = 1, Name = "Анатолий", Phone = "+79999999999", Login = "AnatolyTech", Password = "123456" };
    var secondTechnician = new Technician
      { Id = 2, Name = "Аркадий", Phone = "+79999999999", Login = "ArcadyTech", Password = "123456" };
    var thirdTechnician = new Technician
      { Id = 3, Name = "Юрий", Phone = "+79999999999", Login = "YuriyTech", Password = "123456" };

    #endregion

    #region Инициализация объектов для таблицы Client

    var firstClient = new Client
      { Id = 1, Name = "Анатолий", Phone = "+79999999999", Login = "AnatolyClient", Password = "123456" };
    var secondClient = new Client
      { Id = 2, Name = "Аркадий", Phone = "+79999999999", Login = "ArcadiyClient", Password = "123456" };
    var thirdClient = new Client
      { Id = 3, Name = "Юрий", Phone = "+79999999999", Login = "YuriyClient", Password = "123456" };

    #endregion

    #region Добавление данных в БД

    modelBuilder.Entity<Technician>().HasData(firstTechnician, secondTechnician, thirdTechnician);
    modelBuilder.Entity<Client>().HasData(firstClient, secondClient, thirdClient);

    #endregion
  }
}