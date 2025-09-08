using Microsoft.EntityFrameworkCore;
using PedidoService.Infrastructure.Context;
using System.Reflection;

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
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
);

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

app.UseHttpsRedirection();

// Roteamento para controllers
app.MapControllers();

app.Run();
