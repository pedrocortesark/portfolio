using P.BL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace WPF.Start.Rules
{
    public class ValidationName : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Common.Lib.Infrastructure.ValidationResult<string> vrName = Student.ValidateName(value as string);

            if (!vrName.IsSuccess)
            {
                var error = vrName.Errors[vrName.Errors.Count - 1];
                return new ValidationResult(false, error);
            }

            return new ValidationResult(true, null);
        }

        
    }
}
