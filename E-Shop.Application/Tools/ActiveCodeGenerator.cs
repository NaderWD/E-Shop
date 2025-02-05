namespace E_Shop.Application.Tools
{
    public static class ActiveCodeGenerator
    {
        public static string GenerateRandomCode(int numberOfDigits)
        {
            if (numberOfDigits == 0)
            {
                throw new ArgumentException();
            }

            Random random = new();
            var result = string.Empty;

            for (int i = 0; i < numberOfDigits; i++)
            {
                result += random.Next(0, 10).ToString();
            }
            return result;
        }
    }

}



