using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("departments")]
        public IActionResult GetDepartments()
        {
            var department = _department.GetDepartments().ToList();
            return Ok(department);
        }

        [HttpPost("{name}")]
        public IActionResult CreateDepartment(string name)
        {
            if (string.IsNullOrEmpty(name)) return BadRequest();
            _department.AddDepartment(name);
            return Ok();
        }

        [HttpPut("{ID}/department")]
        public IActionResult UpdateDepartment(int ID, [FromBody] DepartmentVM departmentVM)
        {
            if (ID == 0) return BadRequest();
            
            if (departmentVM is null) return BadRequest();

           _department.UpdateDepartment(departmentVM);

            return Ok(departmentVM);
        }

        [HttpDelete("{departmentID}")]
        public IActionResult DeleteDepartment(int departmentID)
        {
            if (departmentID == 0)
            {
                return BadRequest();
            }
            _department.DeleteDepartment(departmentID);
            
            return Ok();
        }
    }
}
