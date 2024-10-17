namespace EmployeeManagementWebApi.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }

        // Navigation Property
        public Products Product { get; set; }
    }
}
