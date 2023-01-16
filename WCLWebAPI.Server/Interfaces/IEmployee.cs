using WCLWebAPI.Server.Entities;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Interfaces
{
    public interface IEmployee
    {
        IEnumerable<EmployeeVM> GetEmployees();
        EmployeeVM GetEmployeeDetails(int id);
        EmployeeVM AddEmployee(EmployeeVM employee);
        EmployeeVM UpdateEmployee(EmployeeVM employee);
        bool DeleteEmployee(int id);
        bool CheckEmployee(int id);
        void Save();
    }
}
