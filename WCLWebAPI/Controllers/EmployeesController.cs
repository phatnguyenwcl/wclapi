using Microsoft.AspNetCore.Mvc;
using WCLWebAPI.Server.Interfaces;
using WCLWebAPI.Server.ViewModels;

namespace WCLWebAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var result = await _employeeService.GetEmployeesAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeVM employeeVM)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var res = await _employeeService.AddEmployeeAsync(employeeVM);
            return Ok(res);
        }

        [HttpPut("{id}/updateEmployee")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeVM employeeVM)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _employeeService.UpdateEmployeeAsync(id, employeeVM);

            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}/deleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var emp = await _employeeService.DeleteEmployeeAsync(id);
            return Ok(emp);
        }

        [HttpGet("{keyword}/highestWorkingHours")]
        public async Task<IActionResult> GetHighestWorkingHours(string? keyword)
        {
            var result = await _employeeService.GetHighestWorkingHours(keyword);
            return Ok(result);
        }
        
        [HttpGet("{keyword}/getWorkingTimes")]
        public async Task<IActionResult> GetWorkingTimes(string? keyword)
        {
            var result = await _employeeService.GetListWorkingTimes(keyword);
            return Ok(result);
        }
        
        [HttpGet("{id}/employeePayroll")]
        public async Task<IActionResult> EmployeePayroll(int? id)
        {
            var result = await _employeeService.EmployeePayroll(id);
            return Ok(result);
        }
    }
}
