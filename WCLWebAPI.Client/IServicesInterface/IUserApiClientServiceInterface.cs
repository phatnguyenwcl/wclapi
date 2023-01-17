using WCLWebAPI.Server.Common;
using WCLWebAPI.Server.ViewModels.System.Users;
using WCLWebAPI.Server.ViewModels.System.Roles;

namespace WCLWebAPI.Client.IServicesInterface
{
    public interface IUserApiClientServiceInterface
    {
        Task<ApiResult<string>> AuthenticateAsync(LoginRequest request);

        Task<ApiResult<PagedResult<UserVM>>> GetUsersPagingsAsync(GetUserPagingRequest request);

        Task<ApiResult<bool>> RegisterUserAsync(RegisterRequest registerRequest);

        Task<ApiResult<bool>> UpdateUserAsync(Guid id, UserUpdateRequest request);

        Task<ApiResult<UserVM>> GetByIdAsync(Guid id);

        Task<ApiResult<bool>> DeleteAsync(Guid id);

        Task<ApiResult<bool>> RoleAssignAsync(Guid id, RoleAssignRequest request);
    }
}
