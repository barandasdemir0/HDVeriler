using FluentValidation;
using HD_Veriler.Models;

namespace HD_Veriler.Validators
{
    public class InventoryLaptopValidator : AbstractValidator<InventoryLaptop>
    {
        public InventoryLaptopValidator()
        {
            RuleFor(x => x.BrandName)
            .NotEmpty().WithMessage("Markası Boş Olamaz")
            .WithName("Marka")
            .MaximumLength(50).WithMessage("Marka Adı 50 karakterden Fazla olamaz");

            RuleFor(x => x.Ram)
     .NotNull().WithMessage("Ram Boyutu Boş Olamaz")
     .LessThanOrEqualTo(999).WithMessage("Ram Boyutu 3'haneden Büyük Olamaz");

            RuleFor(x => x.Os)
            .NotEmpty().WithMessage("İşletim Sistemi Boş Olamaz")
            .WithName("İşletim Sistemi")
            .MaximumLength(50).WithMessage("İşletim Sistemi 50 karakterden Fazla olamaz");

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

            RuleFor(x => x.Programs)
           .NotEmpty().WithMessage("İçindeki Programlar Boş Olamaz")
           .WithName("Bilgisayarda Bulunan Programlar")
           .MaximumLength(200).WithMessage("200 karakterden Fazla olamaz");

            RuleFor(x => x.Material)
           .NotEmpty().WithMessage("Ek Malzemeler Boş Olamaz")
           .WithName("Yanında Verilen Malzemeler")
           .MaximumLength(200).WithMessage("200 karakterden Fazla olamaz");
        }
    }
}
