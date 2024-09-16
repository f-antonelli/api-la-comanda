using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Repository;
using Microsoft.Extensions.DependencyInjection;




var builder = WebApplication.CreateBuilder(args);


//--------------Services------------------------ | configuracion DB
builder.Services.AddDbContext<DataContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringEF")));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repository
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<MesaRepository>();
builder.Services.AddScoped<EmpleadoRepository>();
builder.Services.AddScoped<ComandaRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
