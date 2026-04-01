using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using SystemBase.Mappers.IMappers;
using SystemBase.Models;
using SystemBase.Models.DTO;
using SystemBase.Repositorio.IRepositorio;
using SystemBase.Services;
using SystemBase.Services.IServices;
using Xunit.Abstractions;

namespace SystemBase.Tests;

public class LoginServiceTests
{
    public Mock<ILoginRepositorio> RepositorioLoginMock = new();
    public Mock<ILoginMapper> LoginMapperMock = new();
    public Mock<ITokenService> TokenServiceMock = new();
    public Mock<IPasswordHasher> PasswordHasherMock = new();
    public Mock<IConfiguration> ConfigurationMock = new();
    public Mock<IUserAssignments>  UserAssignmentsMock = new();
    public Mock<ILogger<LoginService>> Logger = new();

    private readonly LoginService _loginService;
    private readonly ITestOutputHelper _output;

    public LoginServiceTests(ITestOutputHelper output)
    {
        _output = output;
        _loginService = new(
            RepositorioLoginMock.Object,
            LoginMapperMock.Object,
            TokenServiceMock.Object,
            ConfigurationMock.Object,
            PasswordHasherMock.Object,
            UserAssignmentsMock.Object,
            Logger.Object
            );
    }

    [Fact]
    public async Task Login_DebeRetornarErrorSiPropiedadIsEmpty()
    {
        logingDTO loginDto = new logingDTO
        {
            password = "Jhonatan11+",
            userName = ""
        };

        var caseStringempty = await _loginService.Login(loginDto, "Rider", "127.0.0.1");
        Assert.Equal("Usuario y contraseña son requeridos", caseStringempty.error);
        Assert.True(caseStringempty.error != "");
        Assert.True(!caseStringempty.success);
    }

    [Fact]
    public async Task Login_DebeRetornarErrorSiPropiedadIsNull()
    {
        logingDTO loginDto = new logingDTO
        {
            password = "Jhonatan11+",
            userName = null
        };

        var caseStringNull = await _loginService.Login(loginDto, "Rider", "127.0.0.1");
        Assert.Equal("Usuario y contraseña son requeridos", caseStringNull.error);
        Assert.True(caseStringNull.error != "");
        Assert.True(!caseStringNull.success);
    }

    [Fact]
    public async Task Login_SiUsurioNotFoundReturnErrorMesanges()
    {
        logingDTO loginDto = new logingDTO
        {
            password = "Jhonatan11+",
            userName = "Jhoanxp"
        };

        RepositorioLoginMock.Setup(login => login.LoginUser("Jhoanxp")).ReturnsAsync((Users?)null);

        var caseUserNull = await _loginService.Login(loginDto, "Rider", "127.0.0.1");

        Assert.Equal("Credenciales inválidas", caseUserNull.error);
        Assert.True(caseUserNull.error != "");
        Assert.True(!caseUserNull.success);
    }

    [Fact]
    public async Task Login_SiUsurioNotCorrectPasswordReturnErrorMesanges()
    {
        logingDTO loginDto = new logingDTO
        {
            password = "Jhonatan11+",
            userName = "Jhoanxp"
        };
        RepositorioLoginMock.Setup(logig => logig.LoginUser("Jhoanxp")).ReturnsAsync(new Users
        (
            userName: "Jhoanxp",
            password: "$argon2id$v=19$m=32768,t=3,p=2$Md7htI5T4MstYssYBHk3sw$HWnz7XTNLjv8wn8GljlKCA8Cf4P9YinQ44MmocUHx1s",
            name: "Jhonatan"
        ));
        
        PasswordHasherMock.Setup(hash => hash.Verify(
                It.IsAny<string>(),  // contraseña en texto plano
                It.IsAny<string>()    // hash almacenado
            ))
            .Returns(false);

        var caseUserPasswordNotCorrect = await _loginService.Login(loginDto, "Rider", "127.0.0.1");
        Assert.Equal("Credenciales inválidas", caseUserPasswordNotCorrect.error);
    }
}