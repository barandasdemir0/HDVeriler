using FluentValidation;
using HD_Veriler.Models;

namespace HD_Veriler.Validators
{
    public class DepartmanValidator : AbstractValidator<Departman>
    {
        public DepartmanValidator()
        {
            RuleFor(x => x.DepartmanName)
           .NotEmpty().WithMessage("Departman Adı Boş Olamaz")
           .WithName("Ad Ve Soyad")
           .MaximumLength(50).WithMessage("Departman 50 karakterden Fazla olamaz");
        }
    }
}
