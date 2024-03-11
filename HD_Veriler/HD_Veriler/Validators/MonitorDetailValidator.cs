using FluentValidation;
using HD_Veriler.Models;

namespace HD_Veriler.Validators
{
    public class MonitorDetailValidator : AbstractValidator<MonitorDetail>
    {
        public MonitorDetailValidator()
        {
            RuleFor(x => x.Screen)
           .NotEmpty().WithMessage("Ekran Boyutu Boş Olamaz")
           .WithName("Ekran Boyutu")
           .MaximumLength(50).WithMessage("Ekran Boyutu 50 karakterden Fazla olamaz");

            RuleFor(x => x.Input)
           .NotEmpty().WithMessage("Ekran Girişi Boş Olamaz")
           .WithName("Ekran Girişi")
           .MaximumLength(50).WithMessage("Ekran Girişi 50 karakterden Fazla olamaz");

            RuleFor(x => x.Resolution)
            .NotEmpty().WithMessage("Çözünürlük Boş Olamaz")
            .WithName("Çözünürlük")
            .MaximumLength(50).WithMessage("Çözünürlük 50 karakterden Fazla olamaz");

            RuleFor(x => x.Serino)
           .NotEmpty().WithMessage("Serino Boş Olamaz")
           .WithName("Serino")
           .MaximumLength(50).WithMessage("Serino 50 karakterden Fazla olamaz");

         
        }
    }
}
