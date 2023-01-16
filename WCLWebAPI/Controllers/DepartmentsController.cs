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
        private readonly IDepartmentService _department;
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartmentService department, IMapper mapper)
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

        [HttpPut]
        public IActionResult UpdateDepartment(DepartmentVM departmentVM)
        {
            if (departmentVM is null) return NotFound();
            
            var query = _department.GetById(departmentVM.ID);

            if (query is null) return NotFound();

            query.Name = departmentVM.Name;

            _department.Save();

            return Ok(query);
        }

        [HttpDelete]
        public IActionResult DeleteDepartment(int departmentID)
        {
            if (departmentID == 0)
            {
                return NotFound();
            }
            _department.DeleteDepartment(departmentID);
            _department.Save();
            return Ok();
        }
    }
}
