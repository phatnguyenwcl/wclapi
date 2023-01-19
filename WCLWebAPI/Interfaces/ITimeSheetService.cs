using WCLWebAPI.Server.Common;
using WCLWebAPI.Server.Entities;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Interfaces
{
    public interface ITimeSheetService
    {
        Task<ApiResult<IEnumerable<TimeSheetVM>>> GetTimeSheetsAsync();
        Task<ApiResult<TimeSheetVM>> GetTimeSheetDetailsAsync(int id);
        Task<ApiResult<bool>> AddTimeSheetAsync(TimeSheetVM timesheet);
        Task<ApiResult<bool>> UpdateTimeSheetAsync(int id, TimeSheetVM timesheet);
        Task<ApiResult<bool>> DeleteTimeSheetAsync(int id);
        Task<ApiResult<bool>> CheckTimeSheetAsync(int id);
    }
}
