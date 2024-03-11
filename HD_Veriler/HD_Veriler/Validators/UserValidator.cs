using FluentValidation;
using HD_Veriler.Models;

namespace HD_Veriler.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.NameSurname)
            .NotEmpty().WithMessage("İsim Soyİsim Boş Olamaz")
            .WithName("Ad Ve Soyad")
            .MaximumLength(50).WithMessage("İsim Ve Soyİsim 50 karakterden Fazla olamaz");

            RuleFor(x => x.IPV4Adress)
     .NotEmpty().WithMessage("IP Adresi Boş Olamaz")
     .WithName("IP Adresi")
     .Matches(@"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")
         .WithMessage("Geçersiz IP Adresi Formatı");



            RuleFor(x => x.Telephone).NotEmpty().WithMessage("Telefon Boş Olamaz")
           .WithName("Telefon Numarası")
           .MaximumLength(3).WithMessage("Sınırlar içerisinde Telefon Numarası girin");

            RuleFor(x => x.EMail).NotEmpty().WithMessage("Telefon Boş Olamaz")
           .WithName("Telefon Numarası").EmailAddress().
            WithMessage("Geçerli bir e-posta adresi girin.");

            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre alanı boş olamaz.")
            .MinimumLength(8).WithMessage("Şifre en az 8 karakter uzunluğunda olmalıdır.")
            .MaximumLength(20).WithMessage("Şifre en fazla 20 karakter uzunluğunda olabilir.")
            .Matches("[A-Z]").WithMessage("Şifrede en az bir büyük harf bulunmalıdır.")
            .Matches("[a-z]").WithMessage("Şifrede en az bir küçük harf bulunmalıdır.")
            .Matches("[0-9]").WithMessage("Şifrede en az bir rakam bulunmalıdır.")
            .Matches("[!@#$%^&*.,;'^+-]").WithMessage("Şifrede en az bir özel karakter bulunmalıdır.");


          


        }
    }
}
