namespace EmployeeManagementWebApi.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Navigation Property
        public ICollection<Orders> Orders { get; set; }
    }
}
