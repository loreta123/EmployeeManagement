using EmployeeManagementWebApi.Models;
using EmployeeManagementWebApi.Models.DTO;
using EmployeeManagementWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EmployeeManagementWebApi.Controllers
{
    public class ProductsOrders : Controller
    {
        private readonly IOrderService _orderService;
        public ProductsOrders(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("Top5Products")]
        [Authorize]
        public async Task<IActionResult> GetTop5ProductsByOrdersAsync()
        {
            var products = await _orderService.GetTop5ProductsByOrdersAsync();
            return Ok(products);

        }

        [HttpGet("Last30DaysOrders")]
        public async Task<IActionResult> GetOrdersFromLast30DaysAsync()
        {

            var products = await _orderService.GetLast30DaysProductsByOrdersAsync();
            return Ok(products);
           
        }

        [HttpGet("TotalRevenueOrders")]
        public async Task<decimal> GetTotalRevenueAsync()
        {
            var totalRevenue = await _orderService.GetTotalRevenueOrdersAsync();
            return totalRevenue;
        }

    }
}
