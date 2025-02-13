namespace E_Shop.Domain.Enum
{
    public class TicketsEnums
    {
        public enum Section
        {
            Sell,
            Service,
            Support,
        }

        public enum Priority
        {
            NoSoImportant,
            Normal,
            Important,
        }

        public enum State
        {
            Seen,
            Checking,
            Answered,
            closed,
        }
    }
}
