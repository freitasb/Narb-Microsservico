using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using PedidoService.API.Middleware;
using PedidoService.Application.Commands.CriarCliente;
using PedidoService.Application.Interfaces;
using PedidoService.Application.Repositories;
using PedidoService.Infrastructure.Context;
using PedidoService.Infrastructure.Repositories;
using System.Reflection;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<PedidoDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")),
        b => b.MigrationsAssembly(typeof(PedidoDbContext).Assembly.FullName)
    )
);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CriarClienteCommand).Assembly));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

builder.Services.AddHealthChecks()
    .AddDbContextCheck<PedidoDbContext>(tags: new[] { "db" });


// Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger no ambiente de dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

//app.MapHealthChecks("/health", new HealthCheckOptions
//{
//    ResponseWriter = async (context, report) =>
//    {
//        context.Response.ContentType = "application/json";
//        var result = JsonSerializer.Serialize(new
//        {
//            status = report.Status.ToString(),
//            checks = report.Entries.Select(e => new {
//                name = e.Key,
//                status = e.Value.Status.ToString(),
//                description = e.Value.Description
//            })
//        });
//        await context.Response.WriteAsync(result);
//    }
//});

// Roteamento para controllers
app.MapControllers();

app.MapHealthChecks("/health");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    var db = services.GetRequiredService<PedidoDbContext>();

    const int maxAttempts = 10;
    for (int attempt = 1; attempt <= maxAttempts; attempt++)
    {
        try
        {
            logger.LogInformation("Aplicando migrations (tentativa {Attempt}/{Max})...", attempt, maxAttempts);
            db.Database.Migrate(); // ou MigrateAsync() se preferir await
            logger.LogInformation("Migrations aplicadas com sucesso.");
            break;
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Falha ao aplicar migrations (tentativa {Attempt}/{Max}).", attempt, maxAttempts);
            if (attempt == maxAttempts)
            {
                logger.LogError("Não foi possível aplicar migrations após {Max} tentativas. Encerrando.", maxAttempts);
                throw; // opcional: força container falhar e reiniciar
            }

            Thread.Sleep(TimeSpan.FromSeconds(5)); // espera antes de tentar novamente
        }
    }
}


app.Run();
