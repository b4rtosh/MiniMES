using Microsoft.EntityFrameworkCore;

namespace MiniMesTrainApi.Models
{

    public class Parameter
    {
        public int Id { get; set; }
        public string? Name { get; set; } = "";
        public string? Unit { get; set; } = "";
        public ICollection<ProcessParameter> ProcessParameters { get; private set; } = null!;
    }
}