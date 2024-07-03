namespace MiniMesTrainApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public ICollection<Order> Orders { get; set; } = null!;
    }
}