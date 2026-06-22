using SystemBase.Models.Snapshot;
using SystemBase.Repositorio.IRepositorio;
using SystemBase.Services.IServices;

namespace SystemBase.Services;

public class UserService(IUserRepositorio userRepositorio, ILogger<UserService> logger, IHierarchyValidator hierarchyValidator) : IUserService
{
    private readonly ILogger<UserService> _logger = logger;
    private readonly IUserRepositorio _userRepositorio = userRepositorio;
    private readonly IHierarchyValidator _hierarchyValidator = hierarchyValidator;

    public async Task<ResponseService<string>> GetPasswordHash(int id)
    {
        try
        {
            var password = await _userRepositorio.GetPasswordByIdAsync(id);
            if (string.IsNullOrEmpty(password))
                return ResponseService.Error<string>("No existe la contraseña");
            return ResponseService.Success<string>(password);
        }
        catch (InvalidOperationException invalidOperationException)
        {
            _logger.LogError(invalidOperationException,
                $"Error al GetPasswordByIdAsync: \n{invalidOperationException.Message}\n");
            return ResponseService.Error<string>("");
        }
    }

    public async Task<ResponseService<List<userDashboardDTO>>> GetAllUsers(string scope, bool? isActive, bool? isDeleted ,int? page, int? pageSize)
    {
        if (scope != "all")
        {
            var filter = _hierarchyValidator.GenerateFilltersBasic(null, null, 1, 10);
        }
        else
        {
            try
            {
                var filter = _hierarchyValidator.GenerateFilltersBasic(isActive, isDeleted , page, pageSize);
                int totalRefistros = await _userRepositorio.GetUsersCountAsync(filter);
                return ResponseService.Success(await _userRepositorio.GetAllUsers(filter));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError(e.Message);
                return ResponseService.Error<List<userDashboardDTO>>("");
            }

        }

        return null;
    }
}