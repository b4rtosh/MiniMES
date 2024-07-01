public class Process
{
	public long Id { get; private set; }
	public string SerialNumber { get; private set; } = "";
	public long OrderId { get; private set; }
	public Order Order { get; private set; } = null!;
	public ProcessStatus Status { get; private set; } = null!; // check it
	public DateTime DateTime { get; } = DateTime.Now;
}