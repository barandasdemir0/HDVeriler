using FluentValidation;
using HD_Veriler.Models;

namespace HD_Veriler.Validators
{
    public class EquipmentValidator : AbstractValidator<ChangeEquipment>
    {
        public EquipmentValidator()
        {
            RuleFor(x => x.EquipmentName)
           .NotEmpty().WithMessage("Ekipman İsmi Boş Olamaz")
           .WithName("Ekipman Adı")
           .MaximumLength(50).WithMessage("Ekipman Adı 50 karakterden Fazla olamaz");

            RuleFor(x => x.Property)
           .NotEmpty().WithMessage("Ekipman Özellikleri Boş Olamaz")
           .WithName("Ekipman Özelliği")
           .MaximumLength(150).WithMessage("Ekipman Özelliği 150 karakterden Fazla olamaz");

            RuleFor(x => x.Reason)
           .NotEmpty().WithMessage("Ekipman Değişme Boş Olamaz")
           .WithName("Ekipman Değişme Sebebi")
           .MaximumLength(200).WithMessage("Ekipman Değişme 200 karakterden Fazla olamaz");

        }
    }
}
