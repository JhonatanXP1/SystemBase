using SystemBase.Models.DTO;
using SystemBase.Repositorio.IRepositorio;
using SystemBase.Services.IServices;

namespace SystemBase.Services;

public class UserService(
    IUserRepositorio userRepositorio,
    ILogger<UserService> logger,
    IHierarchyValidator hierarchyValidator) : IUserService
{
    private readonly IHierarchyValidator _hierarchyValidator = hierarchyValidator;
    private readonly ILogger<UserService> _logger = logger;
    private readonly IUserRepositorio _userRepositorio = userRepositorio;

    public async Task<ResponseService<string>> GetPasswordHash(int id)
    {
        try
        {
            var password = await _userRepositorio.GetPasswordByIdAsync(id);
            if (string.IsNullOrEmpty(password))
                return ResponseService.Error<string>("No existe la contraseña");
            return ResponseService.Success(password);
        }
        catch (InvalidOperationException invalidOperationException)
        {
            _logger.LogError(invalidOperationException,
                $"Error al GetPasswordByIdAsync: \n{invalidOperationException.Message}\n");
            return ResponseService.Error<string>("");
        }
    }

    public async Task<ResponseService<UsersDashboardDto>> GetAllUsers( bool? isActive, bool? isDeleted,
        int? page, int? pageSize)
    {
            try
            {
                var filter = _hierarchyValidator.GenerateFilltersBasic(isActive, isDeleted, page, pageSize);
                var totalRefistros = await _userRepositorio.GetUsersCountAsync(filter);
                var rows = await _userRepositorio.GetAllUsers(filter);
                var users = new UsersDashboardDto
                {
                    totalRecords = totalRefistros,
                    users = rows,
                    page = page,
                    pageSize = pageSize
                };

                return ResponseService.Success(users);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError(e.Message);
                return ResponseService.Error<UsersDashboardDto>("");
            }
    }
}