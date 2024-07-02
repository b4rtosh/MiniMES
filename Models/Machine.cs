public class Machine
{
	public int Id { get; private set; }
	public string Name { get; private set; }
	public string? Description { get; private set; }

	
	public ICollection<Order> Orders { get; set; } = null!; 
}