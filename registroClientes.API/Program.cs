using Microsoft.OpenApi.Models;
using registroClientes.Infra.IoC;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

DependencyInjection.AddDependencyInjection(builder.Services, builder.Configuration);

builder.Services.AddControllers().AddJsonOptions(opt =>
opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Registro de Clientes - Paraná Banco",
        Version = "v1",
        Description = "Case Técnico tem por objetivo construir uma WebApi desenvolvida em .net 6.0 " +
        "para efetuar o registro de clientes que deverão informar o nome completo, e-mail e uma lista de telefones para receber informações.",
        Contact = new OpenApiContact
        {
            Name = "Nicolas Pereira",
            Url = new Uri("https://www.linkedin.com/in/nasp/")
        },
    });

    var xmlFilenameSummary = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilenameSummary));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Registro de Clientes")

    );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();