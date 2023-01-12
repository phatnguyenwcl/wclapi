using AutoMapper;
using WCLWebAPI.EF;
using WCLWebAPI.Entities;
using WCLWebAPI.Interfaces;
using WCLWebAPI.ViewModels;

namespace WCLWebAPI.Repositories
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

        public void AddDepartment(DepartmentVM department)
        {
            var mapRes = _mapper.Map<DepartmentVM, Department>(department);

            _context.Departments.Add(mapRes);

            _context.SaveChanges();
        }

        public void UpdateDepartment(DepartmentVM department)
        {
            var mapRes = _mapper.Map<DepartmentVM, Department>(department);

            _context.SaveChanges();
        }

        public DepartmentVM DeleteDepartment(int id)
        {
            if (id == 0) return new DepartmentVM();
            
            var query = _context.Departments.FirstOrDefault(x => x.ID == id);
            
            if (query == null) return new DepartmentVM();

            _context.Departments.Remove(query);

            _context.SaveChanges();

            var mapRes = _mapper.Map<Department, DepartmentVM>(query);

            return mapRes;
        }

        public bool CheckDepartment(int id) 
        {
            return _context.Departments.Any(x => x.ID == id);
        }
    }
}
