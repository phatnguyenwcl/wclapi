using AutoMapper;
using WCLWebAPI.Entities;
using WCLWebAPI.ViewModels;

namespace WCLWebAPI.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<Employee, EmployeeVM>();
            CreateMap<TimeSheet, TimeSheetVM>();
        }
    }
}
