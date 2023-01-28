using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WCLWebAPI.Server.Common;
using WCLWebAPI.Server.Constants;
using WCLWebAPI.Server.EF;
using WCLWebAPI.Server.Entities;
using WCLWebAPI.Server.Enums;
using WCLWebAPI.Server.Interfaces;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Repositories
{
    public class EmployeeRepository : IEmployeeService
    {
        private WCLManagementDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeRepository(WCLManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResult<IEnumerable<EmployeeVM>>> GetEmployeesAsync()
        {
            var result = await _context.Employees.ToListAsync();

            if (!result.Any())
            {
                return new ApiErrorResult<IEnumerable<EmployeeVM>> { IsSuccessed = false, Message = Messages.Msg_GetFailList };
            }

            var mapRes = _mapper.Map<List<Employee>, List<EmployeeVM>>(result);

            return new ApiSuccessResult<IEnumerable<EmployeeVM>> { Message = Messages.Msg_GetSuccessList, IsSuccessed = true, ResultObj = mapRes };
        }

        public async Task<ApiResult<EmployeeVM>> GetEmployeeDetailsAsync(int id)
        {
            if (id == 0) return new ApiErrorResult<EmployeeVM>(Messages.Msg_Fail);

            var query = await _context.Employees.FirstOrDefaultAsync(x => x.ID == id);

            var mapRes = _mapper.Map<Employee, EmployeeVM>(query);

            return new ApiSuccessResult<EmployeeVM> { Message = Messages.Msg_Success, ResultObj = mapRes };
        }

        public async Task<ApiResult<bool>> AddEmployeeAsync(EmployeeVM employee)
        {
            var mapRes = _mapper.Map<EmployeeVM, Employee>(employee);

            //Undetermined Department
            var queryDepartment = await _context.Departments.FirstOrDefaultAsync(x => x.Name == "HR");

            if (queryDepartment == null) return new ApiErrorResult<bool>(Messages.Staff_Not_Exist);

            mapRes.DepartmentID = queryDepartment.ID;

            _context.Employees.Add(mapRes);

            var result = await _context.SaveChangesAsync();

            if (result > 0) return new ApiSuccessResult<bool> { Message = Messages.Msg_Success };

            return new ApiErrorResult<bool>(Messages.Staff_Not_Exist);
        }

        public async Task<ApiResult<bool>> UpdateEmployeeAsync(int id, EmployeeVM employee)
        {
            var query = await _context.Employees.FirstOrDefaultAsync(x => x.ID == id);

            if (query == null) return new ApiErrorResult<bool>(Messages.Staff_Not_Exist);

            query.Name = employee.Name;
            query.CCCD = employee.CCCD;
            query.Address = employee.Address;
            query.Phone = employee.Phone;
            query.Marital = employee.Marital;
            query.Gender = employee.Gender;
            query.DepartmentID = employee.DepartmentID;
            query.Imgage = employee.Imgage;
            query.Email = employee.Email;

            _context.Employees.Update(query);

            var result = await _context.SaveChangesAsync();

            if (result > 0) return new ApiSuccessResult<bool> { Message = Messages.Msg_Success };

            return new ApiErrorResult<bool>(Messages.Staff_Not_Exist);
        }

        public async Task<ApiResult<bool>> DeleteEmployeeAsync(int id)
        {
            var query = await _context.Employees.FirstOrDefaultAsync(x => x.ID == id);

            if (query is null) return new ApiErrorResult<bool>(Messages.Staff_Not_Exist);

            _context.Employees.Remove(query);

            var result = await _context.SaveChangesAsync();

            if (result > 0) return new ApiSuccessResult<bool> { Message = Messages.Msg_Success };

            return new ApiErrorResult<bool>(Messages.Staff_Not_Exist);
        }

        public async Task<ApiResult<bool>> CheckEmployeeAsync(int id)
        {
            var res = await _context.Employees.AnyAsync(x => x.ID == id);

            if (!res) return new ApiErrorResult<bool>(Messages.Staff_Not_Exist);

            return new ApiSuccessResult<bool> { Message = Messages.Msg_Success };
        }

        public async Task<EmployeeVM> GetLastedItemAsync()
        {
            var resMap = await _mapper.ProjectTo<EmployeeVM>(_context.Departments.OrderByDescending(x => x.DateCreated)).FirstOrDefaultAsync();
            if (resMap.ID == 0)
                return new EmployeeVM();
            return resMap;
        }

        public async Task<ApiResult<IEnumerable<EmployeeResponse>>> GetHighestWorkingHours(string? keyword)
        {
            List<EmployeeResponse> queryAllWorkings = new List<EmployeeResponse>();

            queryAllWorkings = await GetWorkingTimeSheets(keyword);

            var groupRes = (from qw in queryAllWorkings
                           group qw by qw.ID into grouped
                           select new EmployeeWorkingResponse
                           {
                               ID = grouped.Key,
                               Name = grouped.FirstOrDefault(x => x.ID == grouped.Key).Name,
                               DOB = grouped.FirstOrDefault(x => x.ID == grouped.Key).DOB,
                               CCCD = grouped.FirstOrDefault(x => x.ID == grouped.Key).CCCD,
                               Address = grouped.FirstOrDefault(x => x.ID == grouped.Key).Address,
                               Gender = grouped.FirstOrDefault(x => x.ID == grouped.Key).Gender,
                               IsManager = grouped.FirstOrDefault(x => x.ID == grouped.Key).IsManager,
                               DepartmentID = grouped.FirstOrDefault(x => x.ID == grouped.Key).DepartmentID,
                               StartWorking = grouped.FirstOrDefault(x => x.ID == grouped.Key).StartWorking,
                               EndWorking = grouped.FirstOrDefault(x => x.ID == grouped.Key).EndWorking,
                               BreakStart = grouped.FirstOrDefault(x => x.ID == grouped.Key).BreakStart,
                               BreakEnd = grouped.FirstOrDefault(x => x.ID == grouped.Key).BreakEnd,
                               TotalTime = grouped.Aggregate(new TimeSpan(0), (ts, er) => ts.Add(er.TotalDay))
                           }).ToList();
            
            //parse to totalHours
            groupRes.ForEach(e => {
                e.TotalWorkingHours = string.Format("{0:0.0}", e.TotalTime.TotalHours);
                e.TotalWorkingHour = e.TotalTime.TotalHours;
            });

            var mapRes = _mapper.Map<List<EmployeeWorkingResponse>,List<EmployeeResponse>>(groupRes);

            mapRes.OrderByDescending(x => x.TotalWorkingHour).ToList();

            return new ApiSuccessResult<IEnumerable<EmployeeResponse>> { Message = Messages.Msg_Success, ResultObj = mapRes };
        }

        private async Task<List<EmployeeResponse>> GetWorkingTimeSheets(string? keyword)
        {
            IQueryable<Employee> queryEmployee = _context.Employees;

            if (!string.IsNullOrEmpty(keyword))
            {
                queryEmployee = queryEmployee.Where(x => x.Name.Contains(keyword));
            }

            var isEmployee = queryEmployee.Any();
            
            if (!isEmployee) return new List<EmployeeResponse>();

            var query = await (from e in queryEmployee
                               join t in _context.TimeSheets on e.ID equals t.EmployeeID into group_join
                        from selector in group_join.DefaultIfEmpty()
                            //group s by e.DepartmentID into grouped 
                        select new EmployeeResponse
                        {
                            ID = e.ID,
                            Name = e.Name,
                            DOB = e.DOB,
                            CCCD = e.CCCD,
                            Address = e.Address,
                            Gender = e.Gender,
                            IsManager = e.IsManager,
                            DepartmentID = e.DepartmentID,
                            StartWorking = selector != null ? selector.StartWorking : DateTime.Now,
                            EndWorking = selector != null ? selector.EndWorking : DateTime.Now,
                            BreakStart = selector != null ? selector.BreakStart : DateTime.Now,
                            BreakEnd = selector != null ? selector.BreakEnd : DateTime.Now
                        }).ToListAsync();

            if (!query.Any()) return new List<EmployeeResponse>();

            return query.OrderByDescending(x => x.TotalDay).ToList();
        }
    }
}
