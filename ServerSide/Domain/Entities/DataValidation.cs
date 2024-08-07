using System.Text.RegularExpressions;

namespace MiniMesTrainApi.Domain.Entities;

public static class Validation
{
    public static bool CheckString(string? str)
    {
        return str != null && Regex.IsMatch(str, @"\A(?!\s)[\w\ \-]+(?<!\s)\z");
    }

    public static bool CheckStringNoSpaces(string str)
    {
        return Regex.IsMatch(str, @"\A(?!\s)[\w]+(?<!\s)\z");
    }

    public static bool CheckInteger(string str)
    {
        return Regex.IsMatch(str, @"\A(?!\s)[\d]+(?<!\s)\z");
    }
}