using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using WCLWebAPI.Server.Common;
using WCLWebAPI.Server.Constants;
using WCLWebAPI.Server.EF;
using WCLWebAPI.Server.Entities;
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

            queryAllWorkings = await GetWorkingTimeSheets(null, keyword);

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
                e.TotalWorkingHour = Math.Round(e.TotalTime.TotalHours, 2);
            });

            var mapRes = _mapper.Map<List<EmployeeWorkingResponse>,List<EmployeeResponse>>(groupRes);

            mapRes.OrderByDescending(x => x.TotalWorkingHour).ToList();

            return new ApiSuccessResult<IEnumerable<EmployeeResponse>> { Message = Messages.Msg_Success, ResultObj = mapRes };
        }

        public async Task<ApiResult<IEnumerable<EmployeeResponse>>> GetListWorkingTimes(string? keyword)
        {
            List<EmployeeResponse> queryAllWorkings = new List<EmployeeResponse>();

            queryAllWorkings = await GetWorkingTimeSheets(null, keyword);

            var startTime = new TimeSpan(1, 17, 0, 0);
            var endTime = new TimeSpan(2, 02, 0, 0);

            return new ApiSuccessResult<IEnumerable<EmployeeResponse>> { Message = Messages.Msg_Success, ResultObj = queryAllWorkings };
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

        private async Task<List<EmployeeResponse>> GetWorkingTimeSheets(int? employeeId, string? keyword, string group_type = "Yes")
        {
            IQueryable<Employee> queryEmployee = _context.Employees;
            var query = new List<PayrollResponse>();

            if ((employeeId != null && employeeId != 0 && employeeId != -1) || !string.IsNullOrEmpty(keyword))
            {
                queryEmployee = queryEmployee.Where(x => x.ID == employeeId || x.Name.Contains(keyword));
            }

            var isEmployee = queryEmployee.Any();

            if (!isEmployee) return new List<EmployeeResponse>();
            
            switch (group_type)
            {
                case "Yes":
                    query = await (from e in queryEmployee
                                   join t in _context.TimeSheets on e.ID equals t.EmployeeID into group_join
                                   from selector in group_join.DefaultIfEmpty()
                                   join dp in _context.Departments on (selector != null) ? selector.Employee.DepartmentID : 0 equals dp.ID into group_join_dep
                                   from result in group_join_dep.DefaultIfEmpty()
                                   group selector by selector.EmployeeID into grouped
                                   select new PayrollResponse
                                   {
                                       ID = grouped.FirstOrDefault(x => x.Employee.ID == grouped.Key).Employee.ID,
                                       Name = grouped.FirstOrDefault(x => x.Employee.ID == grouped.Key).Employee.Name,
                                       CCCD = grouped.FirstOrDefault(x => x.Employee.ID == grouped.Key).Employee.CCCD,
                                       Phone = grouped.FirstOrDefault(x => x.Employee.ID == grouped.Key).Employee.Phone,
                                       Email = grouped.FirstOrDefault(x => x.Employee.ID == grouped.Key).Employee.Email,
                                       Address = grouped.FirstOrDefault(x => x.Employee.ID == grouped.Key).Employee.Address,
                                       Gender = grouped.FirstOrDefault(x => x.Employee.ID == grouped.Key).Employee.Gender,
                                       IsManager = grouped.FirstOrDefault(x => x.Employee.ID == grouped.Key).Employee.IsManager,
                                       Salary = grouped.FirstOrDefault(x => x.Employee.ID == grouped.Key).Employee.Salary,
                                       DepartmentName = grouped.FirstOrDefault(x => x.Employee.ID == grouped.Key).Employee.Department.Name
                                       //StartWorking = grouped.StartWorking,
                                       //EndWorking = selector.EndWorking,
                                       //BreakStart = selector.BreakStart,
                                       //BreakEnd = selector.BreakEnd
                                   }).ToListAsync();
                    break;
                default:
                    query = await (from e in queryEmployee
                                   join t in _context.TimeSheets on e.ID equals t.EmployeeID into group_join
                                   from selector in group_join.DefaultIfEmpty()
                                   join dp in _context.Departments on (selector != null) ? selector.Employee.DepartmentID : 0 equals dp.ID into group_join_dep
                                   from result in group_join_dep.DefaultIfEmpty()
                                   
                                   select new PayrollResponse
                                   {
                                       ID = e.ID,
                                       Name = e.Name,
                                       CCCD = e.CCCD,
                                       Phone = e.Phone,
                                       Email = e.Email,
                                       Address = e.Address,
                                       Gender = e.Gender,
                                       IsManager = e.IsManager,
                                       Salary = e.Salary,
                                       DepartmentName = result.Name,
                                       StartWorking = selector.StartWorking,
                                       EndWorking = selector.EndWorking,
                                       BreakStart = selector.BreakStart,
                                       BreakEnd = selector.BreakEnd
                                   }).ToListAsync();
                    break;
            }
           
            var resMap = _mapper.Map<List<PayrollResponse>, List<EmployeeResponse>>(query);

            resMap.ForEach(e =>
            {
                e.TotalWorkingHour = Math.Round(e.TotalDay.TotalHours, 2);
            });

            if (!resMap.Any()) return new List<EmployeeResponse>();

            return resMap;
        }

        

        public async Task<ApiResult<EmployeeResponse>> EmployeePayroll(int? id)
        {
            List<EmployeeResponse> queryAllWorkings = new List<EmployeeResponse>();

            queryAllWorkings = await GetWorkingTimeSheets(id, null);

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
                e.TotalWorkingHour = Math.Round(e.TotalTime.TotalHours, 2);
            });

            var mapRes = _mapper.Map<List<EmployeeWorkingResponse>, List<EmployeeResponse>>(groupRes).FirstOrDefault();

            return new ApiSuccessResult<EmployeeResponse> { Message = Messages.Msg_Success, ResultObj = mapRes };
        }

        private bool IsValid(int? id)
        {
            return false;
        }

    }
}
