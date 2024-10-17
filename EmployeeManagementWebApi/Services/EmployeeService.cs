using EmployeeManagementWebApi.Models.DTO;
using EmployeeManagementWebApi.Models;
using EmployeeManagementWebApi.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementWebApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(string search, string sortBy, bool isDescending, int pageNumber, int pageSize)
        {
            var employees = await _repository.GetAllEmployeesAsync(search, sortBy, isDescending, pageNumber, pageSize);
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _repository.GetEmployeeByIdAsync(id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<int> CreateEmployeeAsync(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                JobTitle = dto.JobTitle,
                Email = dto.Email
            };

            await _repository.AddEmployeeAsync(employee);

            return employee.Id;
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, UpdateEmployeeDto dto)
        {
            var employee = await _repository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }

            // Update only the fields that are provided in the DTO
            if (!string.IsNullOrEmpty(dto.Name))
            {
                employee.Name = dto.Name;
            }

            if (!string.IsNullOrEmpty(dto.JobTitle))
            {
                employee.JobTitle = dto.JobTitle;
            }

            if (!string.IsNullOrEmpty(dto.Email))
            {
                employee.Email = dto.Email;
            }

            await _repository.UpdateEmployeeAsync(employee);

            return employee; // Return the updated employee object
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _repository.DeleteEmployeeAsync(id);
        }
    }

}
