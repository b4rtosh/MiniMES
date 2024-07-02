public class Process
{
	public int Id { get; private set; }
	public string SerialNumber { get; private set; } = "";
	public long OrderId { get; private set; }
	public Order Order { get; private set; } = null!;
	public string Status { get; private set; } = ""; // check it
	public DateTime DateTime { get; } = DateTime.Now;

	public ICollection<ProcessParameter> ProcessParameters { get; private set; } = null!;
}