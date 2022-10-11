using Clean.Architecture.Infrastructure.Data;
using Clean.Architecture.Infrastructure.Repositorio;
using Clean.Architecture.SharedKernel.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Architecture.Infrastructure;

public static class StartupSetup
{
  public static void AddDbContext(this IServiceCollection services, string connectionString) =>
      services.AddDbContext<AppDbContext>(options =>
          options.UseSqlServer(connectionString)).AddScoped <DbContext, AppDbContext>().AddTransient<IRepositorioProducto, RepositorioProducto>(); // will be created in web project root
  
}
