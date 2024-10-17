using EmployeeManagementWebApi.Models;
using EmployeeManagementWebApi.Models.DTO;

namespace EmployeeManagementWebApi.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(string search, string sortBy, bool isDescending, int pageNumber, int pageSize);
        Task<EmployeeDto> GetEmployeeByIdAsync(int id);
        Task<int> CreateEmployeeAsync(CreateEmployeeDto dto);
        Task<Employee> UpdateEmployeeAsync(int id, UpdateEmployeeDto dto);
        Task DeleteEmployeeAsync(int id);
    }
}
