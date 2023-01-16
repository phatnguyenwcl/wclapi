using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleVM>> GetAll();
    }
}
