using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WCLWebAPI.Server.Entities;
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
        public async Task<IActionResult> GetDepartments()
        {
            var department = await _department.GetDepartmentsAsync();
            return Ok(department);
        }

        [HttpPost("{name}")]
        public async Task<IActionResult> CreateDepartment(string name)
        {
            if (string.IsNullOrEmpty(name)) return BadRequest();

            var res = await _department.AddDepartmentAsync(name);

            return Ok(res);
        }

        [HttpPut("{id}/department")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentVM departmentVM)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _department.UpdateDepartmentAsync(id, departmentVM);

            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{departmentID}/deleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(int departmentID)
        {
            var emp = await _department.DeleteDepartmentAsync(departmentID);
            return Ok(emp);
        }
    }
}
