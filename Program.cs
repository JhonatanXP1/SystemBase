using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SystemBase.Data;
using SystemBase.Mappers.IMappers;
using SystemBase.Mappers;
using SystemBase.Repositorio;
using SystemBase.Repositorio.IRepositorio;
using SystemBase.Services;
using SystemBase.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AplicationDbContext>(opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("conexionSqlServer"));
        opt.ConfigureWarnings(w =>
            w.Ignore(RelationalEventId.PendingModelChangesWarning)); //Eliminar cuando sea productivo.
    }
);


//Mappers
builder.Services.AddScoped<ILoginMapper, LoginMapper>();

//Servicios.
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

//Repositorios.
builder.Services.AddScoped<ILoginRepositorio, LoginRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
//app.UseHttpsRedirection();

app.Run();