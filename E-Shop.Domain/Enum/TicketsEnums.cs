using System.ComponentModel.DataAnnotations;



namespace E_Shop.Domain.Enum

{
    public static class TicketsEnums
    {
        public enum Section
        {
            [Display(Name = "فروش")]
            Sale,

            [Display(Name = "پشتیبانی")]
            Support,

            [Display(Name = "مالی")]
            Billing,

            [Display(Name = "فنی")]
            Technical
        }

        public enum Status
        {
            [Display(Name = "باز")]
            Open,

            [Display(Name = "دیده شده")]
            Seen,

            [Display(Name = "دیده نشده")]
            UnSeen,

            [Display(Name = "در حال بررسی")]
            InProgress,

            [Display(Name = "پاسخ داده شده")]
            Resolved,

            [Display(Name = "بسته")]
            closed,
        }

        public enum Priority   
        {
            [Display(Name = "معمولی")]
            Normal,

            [Display(Name = "مهم")]
            Important,

            [Display(Name = "بسیار مهم")]
            VeryImportant,
        }
    }
}
