using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WCLWebAPI.Server.Common;
using WCLWebAPI.Server.Constants;
using WCLWebAPI.Server.EF;
using WCLWebAPI.Server.Entities;
using WCLWebAPI.Server.Interfaces;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Repositories
{
    public class DepartmentRepository : IDepartmentService
    {
        private readonly WCLManagementDbContext _context;
        private readonly IMapper _mapper;
        public DepartmentRepository(WCLManagementDbContext context, IMapper mapper)
        { 
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResult<IEnumerable<DepartmentVM>>> GetDepartmentsAsync()
        {
            var result = await _context.Departments.ToListAsync();

            if (!result.Any())
            {
                return new ApiErrorResult<IEnumerable<DepartmentVM>> { IsSuccessed = false, Message = Messages.Msg_GetFailList };
            }

            var mapRes = _mapper.Map<List<Department>, List<DepartmentVM>>(result);

            return new ApiSuccessResult<IEnumerable<DepartmentVM>> { Message = Messages.Msg_GetSuccessList, IsSuccessed = true, ResultObj = mapRes };
        }

        public async Task<ApiResult<DepartmentVM>> GetDepartmentDetailsAsync(int id)
        {
            if (id == 0) return new ApiErrorResult<DepartmentVM>(Messages.Msg_Fail);

            var query = await _context.Departments.FirstOrDefaultAsync(x => x.ID == id);

            var mapRes = _mapper.Map<Department, DepartmentVM>(query);

            return new ApiSuccessResult<DepartmentVM> { Message = Messages.Msg_Success, ResultObj = mapRes };
        }

        public async Task<ApiResult<bool>> AddDepartmentAsync(string department)
        {
            var model = new Department();

            model.Name = department;

            _context.Departments.Add(model);

            var result = await _context.SaveChangesAsync();

            if (result > 0) return new ApiSuccessResult<bool> { Message = Messages.Msg_Success };

            return new ApiErrorResult<bool>(Messages.Department_Not_Exist);
        }

        public async Task<ApiResult<bool>> UpdateDepartmentAsync(int id, DepartmentVM department)
        {
            var query = await _context.Departments.FirstOrDefaultAsync(x => x.ID == id);

            if (query == null) return new ApiErrorResult<bool>(Messages.Department_Not_Exist);

            query.Name = department.Name;

            _context.Departments.Update(query);

            var result = await _context.SaveChangesAsync();

            if (result > 0) return new ApiSuccessResult<bool> { Message = Messages.Msg_Success };

            return new ApiErrorResult<bool>(Messages.Department_Not_Exist);
        }

        public async Task<ApiResult<bool>> DeleteDepartmentAsync(int id)
        {
            var query = await _context.Departments.FirstOrDefaultAsync(x => x.ID == id);

            if (query is null) return new ApiErrorResult<bool>(Messages.Department_Not_Exist);

            _context.Departments.Remove(query);

            var result = await _context.SaveChangesAsync();

            if (result > 0) return new ApiSuccessResult<bool> { Message = Messages.Msg_Success };

            return new ApiErrorResult<bool>(Messages.Department_Not_Exist);
        }

        public async Task<ApiResult<bool>> CheckDepartmentAsync(int id) 
        {
            var res = await _context.Departments.AnyAsync(x => x.ID == id);

            if (!res) return new ApiErrorResult<bool>(Messages.Department_Not_Exist);

            return new ApiSuccessResult<bool> { Message = Messages.Msg_Success };
        }

        public async Task<ApiResult<DepartmentVM>> GetDepartmentFirstAsync()
        {
            var result = await _mapper.ProjectTo<DepartmentVM>(_context.Departments.OrderByDescending(x => x.DateCreated)).FirstOrDefaultAsync();

            if (result == null) return new ApiErrorResult<DepartmentVM>(Messages.Department_Not_Exist);

            return new ApiSuccessResult<DepartmentVM> { Message = Messages.Msg_Success, ResultObj = result };
        }
    }
}
