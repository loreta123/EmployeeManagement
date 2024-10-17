using AutoMapper;
using EmployeeManagementWebApi.Models;
using EmployeeManagementWebApi.Models.DTO;
using EmployeeManagementWebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EmployeeManagementWebApi.Services
{
    public class OrdersService :IOrderService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public OrdersService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> GetTop5ProductsByOrdersAsync()
        {
            var employees = await _repository.GetTop5ProductsByOrdersAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(employees);
        }
        public async Task<IEnumerable<OrdersDTO>> GetLast30DaysProductsByOrdersAsync()
        {
            var orders = await _repository.GetLast30DaysProductsByOrdersAsync();
            return _mapper.Map<IEnumerable<OrdersDTO>>(orders);
        }
        public async Task<decimal> GetTotalRevenueOrdersAsync()
        {
            var revenues = await _repository.GetTotalRevenueOrdersAsync();
            return revenues;
        }

    }
}
