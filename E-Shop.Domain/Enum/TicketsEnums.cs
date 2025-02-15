namespace E_Shop.Domain.Enum
{
    public class TicketsEnums
    {
        public enum Section
        {
            Sale,
            Support,
            Billing,
            Technical
        }

        public enum Status
        {
            Open,
            Seen,
            UnSeen,
            InProgress,
            Resolved,
            closed,
        }
    }
}
