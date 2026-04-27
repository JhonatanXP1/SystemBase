using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using SystemBase.Authorization;
using SystemBase.Data;
using SystemBase.Mappers;
using SystemBase.Mappers.IMappers;
using SystemBase.Repositorio;
using SystemBase.Repositorio.IRepositorio;
using SystemBase.Services;
using SystemBase.Services.IServices;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => // Implementacion de Bearer para facilitar el testeo de los endpoints.
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.ParameterLocation.Header,
        Description = "Ingresa el token JWT. Ejemplo: eyJhbGci..."
    });

    options.AddSecurityRequirement(doc => new Microsoft.OpenApi.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.OpenApiSecuritySchemeReference("Bearer", doc, null),
            []
        }
    });
    options.OperationFilter<SystemBase.Authorization.SwaggerHeaderFilter>();
});
builder.Services.AddHttpContextAccessor();


// Autenticación JWT
var publicPem = Environment.GetEnvironmentVariable("JWT_PUBLIC_KEY_PEM")
                ?? File.ReadAllText(Path.Combine(builder.Environment.ContentRootPath,
                    builder.Configuration["Jwt:PublicKeyPath"]!));

using var rsa = RSA.Create();
rsa.ImportFromPem(publicPem);
var rsaKey = new RsaSecurityKey(rsa.ExportParameters(false));
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = rsaKey,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddDbContext<AplicationDbContext>(opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("conexionSqlServer"));
        opt.ConfigureWarnings(w =>
            w.Ignore(RelationalEventId.PendingModelChangesWarning)); //Eliminar cuando sea productivo.
    }
);

builder.Host.UseSerilog((_, lc) => lc
    .WriteTo.File(
        "logs/reportsError/reportErrorLog{Date}.log",
        rollingInterval: RollingInterval.Day,
        restrictedToMinimumLevel: LogEventLevel.Error
    )
    .WriteTo.Console()
    .WriteTo.Logger(sub => sub
        .Filter.ByIncludingOnly(e => e.Properties.ContainsKey("Live"))
        .WriteTo.Console()
    )
);

//Mappers
builder.Services.AddScoped<ILoginMapper, LoginMapper>();

//Servicios.
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IHttpContextService, HttpContextService>();
builder.Services.AddScoped<IUserAssignments, UserAssignmentsService>();

//Repositorios.
builder.Services.AddScoped<ILoginRepositorio, LoginRepositorio>();
builder.Services.AddScoped<IEndpointAccessRepositorio, EndpointAccessRepositorio>();

//Autorización por permisos.
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication(); // lee el token y llena HttpContext.User
app.UseAuthorization();
app.MapControllers();
//app.UseHttpsRedirection();

app.Run();