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
using Microsoft.OpenApi.Models;
using Restaurante.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SistemaTurnos.Service;



var builder = WebApplication.CreateBuilder(args);




//---------------------------------------JWT Swagger-----------------------------


builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "JWT", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Ingrese Token",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
        {
        {new OpenApiSecurityScheme
        {
             Reference = new OpenApiReference
             { Type = ReferenceType.SecurityScheme,
              Id = "Bearer"
             }
        },
        new string[]{}

        }
    });
});
//--------------------------------------------------------------------------------


//-----------------------------JWT---------------------------------------------
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

    };
});
//----------------------------------------------------------------

//--------------Services------------------------ | configuracion DB
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringEF")));

//Services
builder.Services.AddScoped<IPedidosService, PedidosService>();
builder.Services.AddScoped<IEmpleadosService, EmpleadosService>();
builder.Services.AddScoped<IComandaService, ComandaService>();
builder.Services.AddScoped<IMesaService, MesaService>();
builder.Services.AddScoped<ILogService, LogService>();


//Repository
builder.Services.AddScoped<EmpleadoPedidosRepository>();

builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<MesaRepository>();
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<ComandaRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(x => new UnitOfWork(x.GetRequiredService<DataContext>(),
    x.GetRequiredService<IPedidoRepository>(), x.GetRequiredService<IEmpleadoRepository>()));
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
