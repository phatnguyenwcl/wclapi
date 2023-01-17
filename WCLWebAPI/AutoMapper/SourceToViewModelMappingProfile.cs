using AutoMapper;
using WCLWebAPI.Server.Entities;
using WCLWebAPI.Server.ViewModels;
using WCLWebAPI.Server.ViewModels.System.Roles;
using WCLWebAPI.Server.ViewModels.System.Users;

namespace WCLWebAPI.Server.AutoMapper
{
    public class SourceToViewModelMappingProfile : Profile
    {
        public SourceToViewModelMappingProfile() 
        {
            CreateMap<Department, DepartmentVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<TimeSheet, TimeSheetVM>().ReverseMap();
            CreateMap<AppRole, RoleVM>().ReverseMap();
            CreateMap<AppUser, UserVM>().ReverseMap();
        }
    }
}
