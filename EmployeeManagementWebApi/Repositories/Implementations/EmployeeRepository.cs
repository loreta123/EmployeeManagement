using EmployeeManagementWebApi.DAL;
using EmployeeManagementWebApi.Models;
using EmployeeManagementWebApi.Models.DTO;
using EmployeeManagementWebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementWebApi.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync(
         string search, string sortBy, bool isDescending,
         int pageNumber, int pageSize)
        {
            var query = _context.Employees.AsQueryable();

            // Search by Name, JobTitle, or Email
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(e => e.Name.Contains(search) ||
                                         e.JobTitle.Contains(search) ||
                                         e.Email.Contains(search));
            }

            // Sort
            if (!string.IsNullOrEmpty(sortBy))
            {
                query = isDescending ? query.OrderByDescending(e => EF.Property<object>(e, sortBy))
                                     : query.OrderBy(e => EF.Property<object>(e, sortBy));
            }

            // Pagination
            return await query.Skip((pageNumber - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync();
        }


        public async Task<IEnumerable<Products>> GetTop5ProductsByOrdersAsync() {

           return await _context.Products
                    .OrderByDescending(p => p.Orders.Count)
                    .Take(5)
                    .ToListAsync();
        }

        public async Task<IEnumerable<Orders>> GetLast30DaysProductsByOrdersAsync() {

            return await  _context.Orders
                .Where(o => o.OrderDate >= DateTime.Now.AddDays(-30))
                .ToListAsync();
        }
        public async Task<decimal> GetTotalRevenueOrdersAsync()
        {

            return await _context.Orders
                .SumAsync(o => o.Quantity * o.Product.Price);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

            }
        }
    }
}
