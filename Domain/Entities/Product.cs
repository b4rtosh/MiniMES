namespace MiniMesTrainApi.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string? Description { get; set; }
    public ICollection<Order> Orders { get; set; } = null!;
}