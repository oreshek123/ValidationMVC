using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ValidationMVC.Models;

namespace ValidationMVC.Filters
{
    public class TrackAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DescriptionOfGood description)
            {
                if (!(description.CityId == 4 || description.CityId == 5))
                {
                    return new ValidationResult("Доставка термогруза возможна только для городов Алматы и Астана");
                }

                if (description.Weight > 1000 && description.TariffsViewId == 1)
                {
                    return new ValidationResult("Доставка груза по данному тарифу возможна только до 1000 килограмм ");
                }
            }
            return ValidationResult.Success;
        }
    }
}