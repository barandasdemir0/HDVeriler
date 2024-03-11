using FluentValidation;
using HD_Veriler.Models;

namespace HD_Veriler.Validators
{
    public class OtherInventoryValidator : AbstractValidator<OtherInventory>
    {
        public OtherInventoryValidator()
        {
            RuleFor(x => x.InventoryName)
           .NotEmpty().WithMessage("Teknoloji Boş Olamaz")
           .WithName("Teknoloji")
           .MaximumLength(50).WithMessage("Teknoloji Adı 50 karakterden Fazla olamaz");

            RuleFor(x => x.BrandName)
           .NotEmpty().WithMessage("Markası Boş Olamaz")
           .WithName("Marka")
           .MaximumLength(50).WithMessage("Marka Adı 50 karakterden Fazla olamaz");

            RuleFor(x => x.Feature)
          .NotEmpty().WithMessage("Ek Malzemeler Boş Olamaz")
          .WithName("Yanında Verilen Malzemeler")
          .MaximumLength(200).WithMessage("200 karakterden Fazla olamaz");

          
        }
    }
}
