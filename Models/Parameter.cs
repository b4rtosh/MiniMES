public class Parameter
{
    public int Id { get; private set; }
    public string Name { get; private set; } = "";
    public string Unit { get; private set; } = "";
    public ICollection<ProcessParameter> ProcessParameters { get; private set; } = null!;
}