using WCLWebAPI.Server.Common;
using WCLWebAPI.Server.Entities;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Interfaces
{
    public interface IDepartmentService
    {
        Task<ApiResult<IEnumerable<DepartmentVM>>> GetDepartmentsAsync();
        Task<ApiResult<DepartmentVM>> GetDepartmentDetailsAsync(int id);
        Task<ApiResult<DepartmentVM>> GetDepartmentFirstAsync();
        Task<ApiResult<bool>> AddDepartmentAsync(string name);
        Task<ApiResult<bool>> UpdateDepartmentAsync(int id, DepartmentVM department);
        Task<ApiResult<bool>> DeleteDepartmentAsync(int id);
        Task<ApiResult<bool>> CheckDepartmentAsync(int id);
    }
}
