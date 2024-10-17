using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementWebApi.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50,ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Job Title is required")]
        [StringLength(50, ErrorMessage = "Job Title can't be longer than 50 characters")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100, ErrorMessage = "Email can't be longer than 100 characters")]
        public string Email { get; set; }
    }
}
