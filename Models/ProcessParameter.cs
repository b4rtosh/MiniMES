using Microsoft.EntityFrameworkCore;

namespace MiniMesTrainApi.Models
{

    public class ProcessParameter
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public int ParameterId { get; set; }
        public int Value { get; set; }
        public Process Process { get; set; } = null!;
        public Parameter Parameter { get; set; } = null!;
      
    }
}