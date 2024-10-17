using AutoMapper;
using EmployeeManagementWebApi.Models.DTO;
using EmployeeManagementWebApi.Models;

namespace EmployeeManagementWebApi.MapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
