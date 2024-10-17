namespace EmployeeManagementWebApi.Models.DTO
{
    public class OrdersDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
    }
}
