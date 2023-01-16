using AutoMapper;
using WCLWebAPI.Server.EF;
using WCLWebAPI.Server.Entities;
using WCLWebAPI.Server.Interfaces;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Repositories
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

        public EmployeeVM AddEmployee(EmployeeVM employee)
        {
            var mapRes = _mapper.Map<EmployeeVM, Employee>(employee);

            _context.Employees.Add(mapRes);
            
            return employee;
        }

        public EmployeeVM UpdateEmployee(EmployeeVM employee)
        {
            var mapRes = _mapper.Map<EmployeeVM, Employee>(employee);

            _context.Employees.Update(mapRes);

            return employee;
        }

        public bool DeleteEmployee(int id)
        {
            var query = _context.Employees.FirstOrDefault(x => x.ID == id);

            if (query is null) return false;

            _context.Employees.Remove(query);

            return true;
        }

        public bool CheckEmployee(int id)
        {
            return _context.Employees.Any(x => x.ID == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
