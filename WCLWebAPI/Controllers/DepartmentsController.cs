using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WCLWebAPI.Server.Interfaces;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartment _department;
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartment department, IMapper mapper)
        {
            _department = department;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            var department = _department.GetDepartments().ToList();
            return Ok(department);
        }

        [HttpPost]
        public IActionResult CreateDepartment([FromBody] DepartmentVM departmentVM)
        {
            if (departmentVM == null && string.IsNullOrEmpty(departmentVM.Name)) return NotFound();
            _department.AddDepartment(departmentVM);
            _department.Save();
            var resultVm = _department.GetDepartmentFirst();
            return Ok(resultVm);
        }
    }
}
