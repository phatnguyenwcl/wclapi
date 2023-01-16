using WCLWebAPI.Server.Entities;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentVM> GetDepartments();
        DepartmentVM GetDepartmentDetails(int id);
        DepartmentVM GetDepartmentFirst();
        DepartmentVM AddDepartment(DepartmentVM department);
        DepartmentVM UpdateDepartment(DepartmentVM department);
        bool DeleteDepartment(int id);
        bool CheckDepartment(int id);
        void Save();
        Department GetById(int id);
    }
}
