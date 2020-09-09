using P.BL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace WPF.Start.Rules
{
    public class ValidationDni : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Common.Lib.Infrastructure.ValidationResult<string> vrDni = Student.ValidateDni(value as string);

            if (!vrDni.IsSuccess)
            {
                var error = vrDni.Errors[vrDni.Errors.Count - 1];
                return new ValidationResult(false, error);
            }

            return new ValidationResult(true, null);
        }
    }
}
