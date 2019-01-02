using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ValidationMVC.Models;

namespace ValidationMVC.Filters
{
    public class SenderAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is Sender sender)
            {
                if (sender.FormOfPaymentId == 3)
                {
                    return ValidationResult.Success;
                }
                bool res = sender.WhenPickUpShipment.Hours >= 8 && sender.WhenPickUpShipment.Hours <= 20;
                if (!res)
                {
                    return new ValidationResult("Заказ можно оформить с 8-00 до 20-00");
                }
            }
            return ValidationResult.Success;
        }
    }
}