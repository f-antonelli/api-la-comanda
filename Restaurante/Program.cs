using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Repository;
using AutoMapper;
using Restaurante.Profiles;
using Microsoft.Extensions.DependencyInjection;
using Restaurante;
using Restaurante.Repository.Interfaces;
using Restaurante.Services;
using Restaurante.Services.Interfaces;




var builder = WebApplication.CreateBuilder(args);


//--------------Services------------------------ | configuracion DB
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringEF")));
//Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//Services
builder.Services.AddScoped<IPedidosService, PedidosService>();

//Repository
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<MesaRepository>();
builder.Services.AddScoped<EmpleadoRepository>();
builder.Services.AddScoped<ComandaRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(x => new UnitOfWork(x.GetRequiredService<DataContext>(),
    x.GetRequiredService<IPedidoRepository>()));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


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
