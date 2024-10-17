using EmployeeManagementWebApi.DAL;
using EmployeeManagementWebApi.Models;
using EmployeeManagementWebApi.Models.DTO;
using EmployeeManagementWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementWebApi.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("Employees")]
        [Authorize]
        public async Task<IActionResult> GetEmployees([FromQuery] string search,
                                                   [FromQuery] string sortBy = "Name",
                                                   [FromQuery] bool isDescending = false,
                                                   [FromQuery] int pageNumber = 1,
                                                   [FromQuery] int pageSize = 10)
        {
            var employees = await _employeeService.GetEmployeesAsync(search, sortBy, isDescending, pageNumber, pageSize);
            return Ok(employees);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost ("Employees")]
        [Authorize]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Employee data is null.");
            }

            if (!ModelState.IsValid)
            {
               
                var errors = ModelState.Values
                                       .SelectMany(v => v.Errors)
                                       .Select(e => e.ErrorMessage)
                                       .ToList();
                return BadRequest(new { Message = "Validation failed", Errors = errors });
            }

            var createdEmployeeId = await _employeeService.CreateEmployeeAsync(dto);

            return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployeeId }, dto); 
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Employee data is null.");
            }

            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(id, dto);
            return Ok(updatedEmployee); // Return 200 OK with the updated employee object
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }

    }
}
