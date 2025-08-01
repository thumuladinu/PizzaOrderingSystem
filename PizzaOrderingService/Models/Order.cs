namespace PizzaOrderingService.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string PizzaType { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string Status { get; set; } = "Placed";
    }
}
