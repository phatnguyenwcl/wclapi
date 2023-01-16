using WCLWebAPI.Server.Common;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Interfaces
{
    public interface IUserApiClientService
    {
        Task<ApiResult<string>> AuthenticateAsync(LoginRequest request);

        Task<ApiResult<bool>> RegisterUserAsync(RegisterRequest registerRequest);

        Task<ApiResult<bool>> UpdateUserAsync(Guid id, UserUpdateRequest request);

        Task<ApiResult<UserVM>> GetByIdAsync(Guid id);

        Task<ApiResult<bool>> DeleteAsync(Guid id);

        Task<ApiResult<bool>> RoleAssignAsync(Guid id, RoleAssignRequest request);
    }
}
