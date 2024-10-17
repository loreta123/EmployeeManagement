using EmployeeManagementWebApi.Models;

namespace EmployeeManagementWebApi.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync(
            string search, string sortBy, bool isDescending,
            int pageNumber, int pageSize);

        Task<IEnumerable<Products>> GetTop5ProductsByOrdersAsync();
        Task<IEnumerable<Orders>> GetLast30DaysProductsByOrdersAsync();
        Task<decimal> GetTotalRevenueOrdersAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}
