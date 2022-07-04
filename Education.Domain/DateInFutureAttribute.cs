using System.ComponentModel.DataAnnotations;

namespace Education.Domain
{
    public class DateInFutureAttribute : ValidationAttribute
    {
        private readonly Func<DateTime> dateTimeNowProvider;

        public DateInFutureAttribute() : this(() => DateTime.Now)
        {

        }

        public DateInFutureAttribute(Func<DateTime> dateTimeNowProvider)
        {
            this.dateTimeNowProvider = dateTimeNowProvider;
            ErrorMessage = "La fecha debe ser del futuro";
        }

        public override bool IsValid(object value)
        {
            bool isValied = false;
            if (value is DateTime dateTime)
            {
                isValied = dateTime > dateTimeNowProvider();
            }
            return isValied;
        }

    }
}
