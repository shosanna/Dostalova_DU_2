using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dostalova_DU_2 {
    class NameValidator : ValidationRule {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
            if (value == null)
                return new ValidationResult(false, "Value cannot be empty.");
            else {
                if (value.ToString().Length < 3 || value.ToString().Length > 20)
                    return new ValidationResult
                    (false, "Name cannot be less than 3 and more than 20 characters long.");
            }
            return ValidationResult.ValidResult;
        }
    }

    class CapacityValidator : ValidationRule {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
            if (value == null)
                return new ValidationResult(false, "Value cannot be empty.");
            else {
                int parsedInt;
                var result = int.TryParse((string)value, out parsedInt);

                if (result) {
                    if (parsedInt < 1 || parsedInt > 100)
                        return new ValidationResult
                        (false, "Capacity cannot be more than 100.");
                } else {
                    return new ValidationResult
                        (false, "Capacity must be a number.");
                }
            }
            return ValidationResult.ValidResult;
        }
    }

    class DescriptionValidator : ValidationRule {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo) {

            if (value.ToString().Length > 100) {
                return new ValidationResult
                    (false, "Name cannot be less than 3 and more than 20 characters long.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
