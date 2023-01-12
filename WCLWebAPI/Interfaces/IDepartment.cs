using WCLWebAPI.Entities;
using WCLWebAPI.ViewModels;

namespace WCLWebAPI.Interfaces
{
    public interface IDepartment
    {
        IEnumerable<DepartmentVM> GetDepartments();
        DepartmentVM GetDepartmentDetails(int id);
        void AddDepartment(DepartmentVM department);
        void UpdateDepartment(DepartmentVM department);
        DepartmentVM DeleteDepartment(int id);
        bool CheckDepartment(int id);
    }
}
