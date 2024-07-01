public class Order
{
    public long Id { get; private set; }
    public string Code { get; private set; } = "";
    public int MachineId { get; private set; }
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }

    public Machine Machine { get; private set; } = null!;
    public Product Product { get; private set; } = null!;
    public ICollection<Process> Processes { get; private set; } = null!;
}