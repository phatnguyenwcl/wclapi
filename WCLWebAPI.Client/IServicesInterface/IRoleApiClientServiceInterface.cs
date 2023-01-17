using WCLWebAPI.Server.Common;
using WCLWebAPI.Server.ViewModels.System.Roles;

namespace WCLWebAPI.Client.IServicesInterface
{
    public interface IRoleApiClientServiceInterface
    {
        Task<ApiResult<List<RoleVM>>> GetAllAsync();
    }
}
