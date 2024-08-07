namespace MiniMesTrainApi.Domain.Entities;

public class ProcessStatus
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public ICollection<Process> Processes { get; set; } = null!;
}