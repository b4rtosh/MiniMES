using System.Reflection;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MiniMesTrainApi.Validation
{
    public static class Validation
    {
        public static bool CheckString(string str)
        {
            if (str == null) return false;
            return Regex.IsMatch(str, @"\A(?!\s)[\w\ \,\.\;]+(?<!\s)\z");
        }

        public static bool CheckInteger(string str)
        {
            if (str == null) return false;
            return Regex.IsMatch(str, @"\A(?!\s)[\d]+(?<!\s)\z");
        }
    }
}