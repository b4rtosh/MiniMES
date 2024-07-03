using System.Text.RegularExpressions;

namespace MiniMesTrainApi.Models
{
    public static class Validation
    {
        public static bool CheckString(string? str)
        {
            if (str == null) return false;
            return Regex.IsMatch(str, @"\A(?!\s)[\w\ \,\.\;]+(?<!\s)\z");
        }

        public static bool CheckStringNoSpaces(string str)
        {
            if (str == null) return false;
            return Regex.IsMatch(str, @"\A(?!\s)[\w]+(?<!\s)\z");
        }
        public static bool CheckInteger(string str)
        {
            if (str == null) return false;
            return Regex.IsMatch(str, @"\A(?!\s)[\d]+(?<!\s)\z");
        }
    }
}