using AutoMapper;
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

        public void AddDepartment(string department)
        {
            var departmentModel = new Department();
            departmentModel.Name = department;
            _context.Departments.Add(departmentModel);
            _context.SaveChanges();
        }

        public void UpdateDepartment(DepartmentVM department)
        {
            var query = _context.Departments.FirstOrDefault(x => x.ID == department.ID);
            if (query != null)
            {
                query.Name = department.Name;
                _context.Departments.Update(query);
                
                _context.SaveChanges();
            }
        }

        public bool DeleteDepartment(int id)
        {            
            var query = _context.Departments.FirstOrDefault(x => x.ID == id);

            if (query is null) return false;

            _context.Departments.Remove(query);

            _context.SaveChanges();

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

        public Department GetById(int id)
        {
            return _context.Departments.FirstOrDefault(x => x.ID == id);
        }
    }
}
