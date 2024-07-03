using MiniMesTrainApi.Validation;

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

    public Order(string id, string code, int machineId, int productId, string quantity)
    {
        
        if (Validation.CheckString(code)) Code = code;
        else throw new Exception("Wprowadzony kod jest niepoprawny!");
        MachineId = machineId;
        ProductId = productId;
        if (Validation.CheckInteger(quantity)) Quantity = Convert.ToInt32(quantity);
        else throw new Exception("Wprowadzony opis jest niepoprawny");
    }
}