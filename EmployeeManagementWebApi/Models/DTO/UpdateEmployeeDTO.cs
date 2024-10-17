using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementWebApi.Models.DTO
{
    public class UpdateEmployeeDto
    {
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string JobTitle { get; set; }
    }

}
