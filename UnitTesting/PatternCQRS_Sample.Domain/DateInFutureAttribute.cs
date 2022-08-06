using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternCQRS_Sample.Domain
{
    public class DateInFutureAttribute: ValidationAttribute
    {
        private readonly Func<DateTime> _datetimeNowProvider;
        public DateInFutureAttribute() : this(() => DateTime.Now) { }

        public DateInFutureAttribute(Func<DateTime> datetimeProvider)
        {
            _datetimeNowProvider = datetimeProvider;
            ErrorMessage = "Date need to be a future date";
        }

        public override bool IsValid(object value)
        {
            bool isValid = false;
            if (value is DateTime dateTime)
            {
                isValid = dateTime > _datetimeNowProvider();
            }
            return isValid;
        }
    }
}
