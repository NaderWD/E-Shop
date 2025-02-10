namespace E_Shop.Application.Tools
{
    public static class CodeGenerator
    {
        private static readonly Random _random = new();

        public static string GenerateCode()
        {
            return _random.Next(100000, 999999).ToString();
        }
    }
}
