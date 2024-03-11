using FluentValidation;
using HD_Veriler.Models;

namespace HD_Veriler.Validators
{
    public class ComputerDetailValidator : AbstractValidator<ComputerDetail>
    {
        public ComputerDetailValidator()
        {

            RuleFor(x => x.Ram)
    .NotNull().WithMessage("Ram Boyutu Boş Olamaz")
    .LessThanOrEqualTo(999).WithMessage("Ram Boyutu 3'haneden Büyük Olamaz");



            RuleFor(x => x.Os)
            .NotEmpty().WithMessage("İşletim Sistemi Boş Olamaz")
            .WithName("İşletim Sistemi")
            .MaximumLength(50).WithMessage("İşletim Sistemi 50 karakterden Fazla olamaz");

            RuleFor(x => x.OsSerialName)
          .NotEmpty().WithMessage("Serial Name Boş Olamaz")
          .WithName("Bütün Office Windows autocad ve daha fazla seri numaralarını yazınız")
          .MaximumLength(350).WithMessage("Serial Name 350 karakterden Fazla olamaz");

            RuleFor(x => x.Cpu)
           .NotEmpty().WithMessage("İşlemcisi Boş Olamaz")
           .WithName("İşlemci")
           .MaximumLength(50).WithMessage("İşlemci 50 karakterden Fazla olamaz");

            RuleFor(x => x.StorageHDD)
            .NotEmpty().WithMessage("HDD Depolama Sistemi Boş Olamaz")
            .WithName("HDD")
            .MaximumLength(50).WithMessage("HDD Depolama Sistemi 50 karakterden Fazla olamaz");

            RuleFor(x => x.StorageSDD)
           .NotEmpty().WithMessage("SDD Depolama Sistemi Boş Olamaz")
           .WithName("SDD")
           .MaximumLength(50).WithMessage("SDD Depolama Sistemi 50 karakterden Fazla olamaz");

            RuleFor(x => x.DisplayCard)
           .NotEmpty().WithMessage("Ekran Kartı Boş Olamaz")
           .WithName("Ekran Kartı")
           .MaximumLength(50).WithMessage("Ekran Kartı 50 karakterden Fazla olamaz");

            RuleFor(x => x.MotherBoard)
           .NotEmpty().WithMessage("Ana Kartı Boş Olamaz")
           .WithName("Ana Kart")
           .MaximumLength(50).WithMessage("Ana Kart 50 karakterden Fazla olamaz");

        
      


        }
    }
}
