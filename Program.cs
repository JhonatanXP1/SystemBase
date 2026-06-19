using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Serilog;
using Serilog.Events;
using SystemBase.Authorization;
using SystemBase.Data;
using SystemBase.Mappers;
using SystemBase.Mappers.IMappers;
using SystemBase.Repositorio;
using SystemBase.Repositorio.IRepositorio;
using SystemBase.Services;
using SystemBase.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins(
                "http://localhost:4200",
                "http://localhost:4201",
                "https://localhost:4200"
            )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => // Implementacion de Bearer para facilitar el testeo de los endpoints.
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingresa el token JWT. Ejemplo: eyJhbGci..."
    });

    options.AddSecurityRequirement(doc => new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecuritySchemeReference("Bearer", doc),
            []
        }
    });
    options.OperationFilter<SwaggerHeaderFilter>();
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
        "Logs/reportsError/reportErrorLog{Date}.log",
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
builder.Services.AddScoped<IUserService, UserService>();

//Repositorios.
builder.Services.AddScoped<ILoginRepositorio, LoginRepositorio>();
builder.Services.AddScoped<IEndpointAccessRepositorio, EndpointAccessRepositorio>();
builder.Services.AddScoped<IUserRepositorio, UserRepositorio>();

//Autorización por permisos.
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.Use(async (context, next) =>
    {
        context.Response.Headers["Content-Security-Policy"] =
            "default-src 'self'; " +
            "script-src 'self' 'unsafe-inline' 'unsafe-eval'; " +
            "style-src 'self' 'unsafe-inline'; " +
            "img-src 'self' data:; " +
            "font-src 'self' data:; " +
            "connect-src 'self' ws://localhost:4200 http://localhost:5259;";

        await next();
    });
}
else
{
    app.Use(async (context, next) =>
    {
        context.Response.Headers["Content-Security-Policy"] =
            "default-src 'self'; " +
            "script-src 'self'; " +
            "style-src 'self'; " +
            "img-src 'self' data:; " +
            "font-src 'self'; " +
            "connect-src 'self' https://api.midominio.com; " +
            "object-src 'none'; " +
            "frame-ancestors 'none';";

        await next();
    });
}

app.UseCors("AllowAngular");
app.UseAuthentication(); // lee el token y llena HttpContext.User
app.UseAuthorization();
app.MapControllers();
//app.UseHttpsRedirection();

app.Run();