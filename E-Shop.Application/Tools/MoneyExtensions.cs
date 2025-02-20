namespace E_Shop.Application.Tools
{
    public static class MoneyExtensions
    {

        public static string ToMoney(this int price)
        {
            return price.ToString("#,0");
        }

    }
}
