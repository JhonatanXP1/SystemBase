using SystemBase.Services.IServices;

namespace SystemBase.Services;

public class UserAssignmentsService(IUserAssignments userAssignments)
{
    private readonly IUserAssignments _UserAssignments = userAssignments;

    bool getPermissionFromAssignate()
    {
        
        return true;
    }
}