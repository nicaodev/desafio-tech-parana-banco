using Microsoft.OpenApi.Models;
using registroClientes.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

DependencyInjection.AddDependencyInjection(builder.Services, builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Registro de Clientes - Paran� Banco", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Registro de Clientes"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();