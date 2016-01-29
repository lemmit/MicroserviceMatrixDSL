namespace MicroserviceMatrixDSL.FunctionalToolkit.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            return str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1);
        }
    }
}
