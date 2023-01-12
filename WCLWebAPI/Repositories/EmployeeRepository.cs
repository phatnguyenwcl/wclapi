using AutoMapper;
using WCLWebAPI.EF;
using WCLWebAPI.Entities;
using WCLWebAPI.Interfaces;
using WCLWebAPI.ViewModels;

namespace WCLWebAPI.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        private WCLManagementDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeRepository(WCLManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeVM> GetEmployees()
        {
            var result = _context.Employees.ToList();

            if (!result.Any())
            {
                return new List<EmployeeVM>();
            }

            var mapRes = _mapper.Map<List<Employee>, List<EmployeeVM>>(result);

            return mapRes;
        }

        public EmployeeVM GetEmployeeDetails(int id)
        {
            if (id == null) return new EmployeeVM();

            var query = _context.Employees.FirstOrDefault(x => x.ID == id);

            var mapRes = _mapper.Map<Employee, EmployeeVM>(query);

            return mapRes;
        }

        public void AddEmployee(EmployeeVM employee)
        {
            var mapRes = _mapper.Map<EmployeeVM, Employee>(employee);

            _context.Employees.Add(mapRes);

            _context.SaveChanges();
        }

        public void UpdateEmployee(EmployeeVM employee)
        {
            var mapRes = _mapper.Map<EmployeeVM, Employee>(employee);

            _context.SaveChanges();
        }

        public EmployeeVM DeleteEmployee(int id)
        {
            if (id == 0) return new EmployeeVM();

            var query = _context.Employees.FirstOrDefault(x => x.ID == id);

            if (query == null) return new EmployeeVM();

            _context.Employees.Remove(query);

            _context.SaveChanges();

            var mapRes = _mapper.Map<Employee, EmployeeVM>(query);

            return mapRes;
        }

        public bool CheckEmployee(int id)
        {
            return _context.Employees.Any(x => x.ID == id);
        }
    }
}
