using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Xml.Schema;
using WCLWebAPI.Server.Common;
using WCLWebAPI.Server.Constants;
using WCLWebAPI.Server.EF;
using WCLWebAPI.Server.Entities;
using WCLWebAPI.Server.Interfaces;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Repositories
{
    public class TimeSheetRepository : ITimeSheetService
    {
        private WCLManagementDbContext _context;
        private readonly IMapper _mapper;
        public TimeSheetRepository(WCLManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResult<IEnumerable<TimeSheetResponse>>> GetTimeSheetsAsync()
        {
            var result = await _context.TimeSheets.ToListAsync();
            if (!result.Any())
            {
                return new ApiErrorResult<IEnumerable<TimeSheetResponse>> { IsSuccessed = false, Message = Messages.Msg_GetFailList };
            }
            
            var mapRes = _mapper.Map<List<TimeSheet>, List<TimeSheetResponse>>(result);

            return new ApiSuccessResult<IEnumerable<TimeSheetResponse>> { Message = Messages.Msg_GetSuccessList, IsSuccessed = true, ResultObj = mapRes };
        }

        public async Task<ApiResult<TimeSheetResponse>> GetTimeSheetDetailsAsync(int id)
        {
            if (id == 0) return new ApiErrorResult<TimeSheetResponse>(Messages.Msg_Fail);

            var query = await _context.TimeSheets.FirstOrDefaultAsync(x => x.ID == id);

            var mapRes = _mapper.Map<TimeSheet, TimeSheetResponse>(query);

            return new ApiSuccessResult<TimeSheetResponse> { Message = Messages.Msg_Success, ResultObj = mapRes };
        }

        public async Task<ApiResult<bool>> AddTimeSheetAsync(TimeSheetVM timeSheet)
        {
            var model = new TimeSheet();

            var queryEmployee = await _context.Employees.FirstOrDefaultAsync(x => x.ID == timeSheet.EmployeeID);

            if (queryEmployee is null) return new ApiErrorResult<bool>(Messages.Staff_Not_Exist);

            var mapRes = _mapper.Map<TimeSheetVM, TimeSheet>(timeSheet);

            _context.TimeSheets.Add(mapRes);

            var result = await _context.SaveChangesAsync();

            if (result > 0) return new ApiSuccessResult<bool> { Message = Messages.Msg_Success };

            return new ApiErrorResult<bool>(Messages.TimeSheet_Not_Exist);
        }

        public async Task<ApiResult<bool>> UpdateTimeSheetAsync(int id, TimeSheetVM timeSheet)
        {
            var queryEmployee = await _context.Employees.FirstOrDefaultAsync(x => x.ID == timeSheet.EmployeeID);

            if (queryEmployee is null) return new ApiErrorResult<bool>(Messages.Staff_Not_Exist);

            var queryTimeSheet = await _context.TimeSheets.FirstOrDefaultAsync(x => x.ID == id);

            if (queryTimeSheet is null) return new ApiErrorResult<bool>(Messages.TimeSheet_Not_Exist);

            queryTimeSheet.EmployeeID = timeSheet.EmployeeID;
            queryTimeSheet.StartWorking = timeSheet.StartWorking;
            queryTimeSheet.EndWorking = timeSheet.EndWorking;
            queryTimeSheet.BreakStart = timeSheet.BreakStart;
            queryTimeSheet.BreakEnd = timeSheet.BreakEnd;

            _context.TimeSheets.Update(queryTimeSheet);

            var result = await _context.SaveChangesAsync();

            if (result > 0) return new ApiSuccessResult<bool> { Message = Messages.Msg_Success };

            return new ApiErrorResult<bool>(Messages.TimeSheet_Not_Exist);
        }

        public async Task<ApiResult<bool>> DeleteTimeSheetAsync(int id)
        {
            var query = await _context.TimeSheets.FirstOrDefaultAsync(x => x.ID == id);

            if (query is null) return new ApiErrorResult<bool>(Messages.TimeSheet_Not_Exist);

            _context.TimeSheets.Remove(query);

            var result = await _context.SaveChangesAsync();

            if (result > 0) return new ApiSuccessResult<bool> { Message = Messages.Msg_Success };

            return new ApiErrorResult<bool>(Messages.TimeSheet_Not_Exist);
        }

        public async Task<ApiResult<bool>> CheckTimeSheetAsync(int id)
        {
            var res = await _context.TimeSheets.AnyAsync(x => x.ID == id);

            if (!res) return new ApiErrorResult<bool>(Messages.Msg_Fail);

            return new ApiSuccessResult<bool> { Message = Messages.Msg_Success };
        }
    }
}
