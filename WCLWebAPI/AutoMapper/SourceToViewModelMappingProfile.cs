using AutoMapper;
using WCLWebAPI.Server.Entities;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.AutoMapper
{
    public class SourceToViewModelMappingProfile : Profile
    {
        public SourceToViewModelMappingProfile() 
        {
            CreateMap<Department, DepartmentVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<TimeSheet, TimeSheetVM>().ReverseMap();
        }
    }
}
