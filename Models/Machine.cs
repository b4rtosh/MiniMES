using MiniMesTrainApi.Validation;

public class Machine
{
	public int Id { get; private set; }
	public string Name { get; private set; }
	public string? Description { get; private set; }

	

	public ICollection<Order> Orders { get; set; } = null!;

    public Machine(string id, string name, string description)
    {
        if (Validation.CheckInteger(id)) Id = Convert.ToInt32(id);
        else throw new Exception("Wprowadzony numer jest niepoprawny!");
        if (Validation.CheckString(name)) Name = name;
        else throw new Exception("Wprowadzona nazwa jest niepoprawna!");
        if (Validation.CheckString(description)) Description = description;
        else throw new Exception("Wprowadzony opis jest niepoprawny");
    }
}