using WCLWebAPI.Entities;
using WCLWebAPI.ViewModels;

namespace WCLWebAPI.Interfaces
{
    public interface IEmployee
    {
        IEnumerable<EmployeeVM> GetEmployees();
        EmployeeVM GetEmployeeDetails(int id);
        void AddEmployee(EmployeeVM employee);
        void UpdateEmployee(EmployeeVM employee);
        EmployeeVM DeleteEmployee(int id);
        bool CheckEmployee(int id);
    }
}
