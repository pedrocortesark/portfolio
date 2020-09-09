using P.BL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace WPF.Start.Rules
{
    public class ValidationChair : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Common.Lib.Infrastructure.ValidationResult<int> vrChair = Student.ValidateChair(value as string);

            if (!vrChair.IsSuccess)
            {
                var error = vrChair.Errors[vrChair.Errors.Count - 1];
                return new ValidationResult(false, error);
            }

            return new ValidationResult(true, null);
        }
    }
}
