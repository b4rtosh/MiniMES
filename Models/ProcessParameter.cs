public class ProcessParameter
{
    public int Id { get; private set; }
    public int ProcessId { get; private set; }
    public int ParameterId { get; private set; }
    public int Value { get; private set; }
    public Process Process { get; private set; } = null!;
    public Parameter Parameter { get; private set; } = null!;
}