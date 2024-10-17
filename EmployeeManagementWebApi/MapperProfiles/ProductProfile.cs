using AutoMapper;
using EmployeeManagementWebApi.Models.DTO;
using EmployeeManagementWebApi.Models;

namespace EmployeeManagementWebApi.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() {

            CreateMap<Products, ProductDTO>();
            CreateMap<ProductDTO, Products>();
        }
    }
}
