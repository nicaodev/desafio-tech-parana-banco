using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using registroClientes.Application.Dtos;
using registroClientes.Application.Interfaces;
using registroClientes.Application.MappingAutoMapper;
using registroClientes.Application.Services;
using registroClientes.Application.Validators;
using registroClientes.Domain.Interfaces;
using registroClientes.Infra.Data.Context;
using registroClientes.Infra.Data.Repository;
using System.Reflection;

namespace registroClientes.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddControllers()
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

        services.AddScoped<IRegistroRepository, RegistroRepository>();
        services.AddScoped<IRegistroService, RegistroService>();

        // Validator
        services.AddTransient<IValidator<ClienteDto>, ClienteValidator>();
        services.AddTransient<IValidator<TelefoneDto>, TelefoneValidator>();

        services.AddAutoMapper(typeof(DomainToDto));

        return services;
    }
}