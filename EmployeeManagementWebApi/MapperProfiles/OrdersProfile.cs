using AutoMapper;
using EmployeeManagementWebApi.Models.DTO;
using EmployeeManagementWebApi.Models;

namespace EmployeeManagementWebApi.MapperProfiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile() {

            CreateMap<Orders, OrdersDTO>();
            CreateMap<OrdersDTO, Orders>();
        }
    }
}
