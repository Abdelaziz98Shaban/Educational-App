using System.ComponentModel.DataAnnotations;

namespace UniAppDay2.Models
{
    public class RangeAdressAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value !=null)
            {
                string address = value.ToString().ToLowerInvariant();

                if(address == "cairo" || address == "alex" || address == "menofia")
                {
                    return ValidationResult.Success;
                }
            }
                    return new ValidationResult("Adress must be Cairo or Alex or Menofia");
        }
    }
}
