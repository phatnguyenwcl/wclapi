
using WCLWebAPI.Server.ViewModels.System.Roles;

namespace WCLWebAPI.Server.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleVM>> GetAll();
    }
}
