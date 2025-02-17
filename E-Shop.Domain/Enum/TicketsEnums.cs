namespace E_Shop.Domain.Enum


{
    public static class TicketsEnums
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

        public enum Priority   
        {
            Normal,
            Important,
            veryImportant,
        }
    }
}
