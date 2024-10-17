using EmployeeManagementWebApi.Models.DTO;
using EmployeeManagementWebApi.Models;
using AutoMapper;
using EmployeeManagementWebApi.Repositories.Interfaces;

namespace EmployeeManagementWebApi.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<ProductDTO>> GetTop5ProductsByOrdersAsync();
        Task<IEnumerable<OrdersDTO>> GetLast30DaysProductsByOrdersAsync();
        Task<decimal> GetTotalRevenueOrdersAsync();

    }
}
