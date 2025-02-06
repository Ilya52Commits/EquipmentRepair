using EquipmentRepairDomain.EntityFramework;
using EquipmentRepairDomain.EntityFramework.Models;
using EquipmentRepairDomain.Repositories.Interfaces;
using EquipmentRepairDomain.Repositories.Repositories;
using EquipmentRepairDomain.Services;
using EquipmentRepairDomain.Services.CurrentUserServices;
using EquipmentRepairDomain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentRepairDomain;

public static class ServiceConfigurator
{
  /// <summary>
  ///     Логика конфигурации сервисов
  /// </summary>
  /// <param name="services"></param>
  /// <param name="configuration"></param>
  public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
  {
    // Добавление контекста базы данных
    services.AddDbContext<Context>(options =>
    {
      var dataProvider = configuration["DataProvider"];

      switch (dataProvider)
      {
        case "MsSql":
          options.UseLazyLoadingProxies().UseSqlServer(configuration["MsSqlDatabase"]);
          break;
        case "PgSql":
          options.UseLazyLoadingProxies().UseNpgsql(configuration["PgSqlDatabase"]);
          break;
      }
    });

    // Добавление репозитория в зависимости от DataProvider
    var provider = configuration["DataProvider"];

    switch (provider)
    {
      case "MsSql":
      case "PgSql":
        services.AddSingleton<IRepository<Client>, SqlRepository<Client>>();
        services.AddSingleton<IRepository<Technician>, SqlRepository<Technician>>();
        services.AddSingleton<IRepository<Request>, SqlRepository<Request>>();
        break;
    }

    services.AddSingleton<ISessionService, SessionService>();

    // Регистрация UserService
    services.AddSingleton<ClientService>();
    // Регистрация TechnicianService
    services.AddSingleton<TechnicianService>();
    // Регистрация RequestService 
    services.AddSingleton<RequestService>();
  }
}