using WCLWebAPI.Server.Common;
using WCLWebAPI.Server.Entities;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Interfaces
{
    public interface IEmployeeService
    {
        Task<ApiResult<IEnumerable<EmployeeVM>>> GetEmployeesAsync();
        Task<ApiResult<EmployeeVM>> GetEmployeeDetailsAsync(int id);
        Task<ApiResult<bool>> AddEmployeeAsync(EmployeeVM employee);
        Task<ApiResult<bool>> UpdateEmployeeAsync(int id, EmployeeVM employee);
        Task<ApiResult<bool>> DeleteEmployeeAsync(int id);
        Task<ApiResult<bool>> CheckEmployeeAsync(int id);
        Task<ApiResult<IEnumerable<EmployeeResponse>>> GetHighestWorkingHours(string? keyword);
    }
}
