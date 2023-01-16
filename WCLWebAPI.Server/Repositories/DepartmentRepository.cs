using AutoMapper;
using WCLWebAPI.Server.EF;
using WCLWebAPI.Server.Entities;
using WCLWebAPI.Server.Interfaces;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Repositories
{
    public class DepartmentRepository : IDepartment
    {
        private readonly WCLManagementDbContext _context;
        private readonly IMapper _mapper;
        public DepartmentRepository(WCLManagementDbContext context, IMapper mapper)
        { 
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<DepartmentVM> GetDepartments()
        {
            var result = _context.Departments.ToList();
            
            if (!result.Any())
            {
                return new List<DepartmentVM>();
            }

            var mapRes = _mapper.Map<List<Department>, List<DepartmentVM>>(result);

            return mapRes;
        }

        public DepartmentVM GetDepartmentDetails(int id)
        {
            if (id == null) return new DepartmentVM();

            var query = _context.Departments.FirstOrDefault(x => x.ID == id);

            var mapRes = _mapper.Map<Department, DepartmentVM>(query);

            return mapRes;
        }

        public DepartmentVM AddDepartment(DepartmentVM department)
        {
            var mapRes = _mapper.Map<DepartmentVM, Department>(department);

            _context.Departments.Add(mapRes);

            return department;
        }

        public DepartmentVM UpdateDepartment(DepartmentVM department)
        {
            var mapRes = _mapper.Map<DepartmentVM, Department>(department);

            _context.Departments.Update(mapRes);

            return department;
        }

        public bool DeleteDepartment(int id)
        {            
            var query = _context.Departments.FirstOrDefault(x => x.ID == id);

            if (query is null) return false;

            _context.Departments.Remove(query);

            return true;
        }

        public bool CheckDepartment(int id) 
        {
            return _context.Departments.Any(x => x.ID == id);
        }

        public DepartmentVM GetDepartmentFirst()
        {
            return _mapper.ProjectTo<DepartmentVM>(_context.Departments.OrderByDescending(x => x.DateCreated)).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
