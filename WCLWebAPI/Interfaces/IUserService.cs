using WCLWebAPI.Server.Common;
using WCLWebAPI.Server.ViewModels.System.Roles;
using WCLWebAPI.Server.ViewModels.System.Users;

namespace WCLWebAPI.Server.Interfaces
{
    public interface IUserService
    {
        Task<ApiResult<string>> AuthencateAsync(LoginRequest request);

        Task<ApiResult<bool>> RegisterAsync(RegisterRequest request);

        Task<ApiResult<bool>> UpdateAsync(Guid id, UserUpdateRequest request);

        Task<ApiResult<PagedResult<UserVM>>> GetUsersPagingAsync(GetUserPagingRequest request);

        Task<ApiResult<UserVM>> GetByIdAsync(Guid id);

        Task<ApiResult<bool>> DeleteAsync(Guid id);

        Task<ApiResult<bool>> RoleAssignAsync(Guid id, RoleAssignRequest request);

        Task<ApiResult<int>> SaveAsync();
    }
}
