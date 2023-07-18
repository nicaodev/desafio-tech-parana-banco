using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using registroClientes.Application.Interfaces;
using registroClientes.Application.Services;
using registroClientes.Domain.Interfaces;
using registroClientes.Infra.Data.Context;
using registroClientes.Infra.Data.Repository;

namespace registroClientes.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IRegistroRepository, RegistroRepository>();
        services.AddScoped<IRegistroService, RegistroService>();

        return services;
    }
}