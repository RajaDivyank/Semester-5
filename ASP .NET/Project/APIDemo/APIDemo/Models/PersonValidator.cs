using FluentValidation;
namespace APIDemo.Models
{
    public class PersonValidator : AbstractValidator<PersonModel>
    {
        public Boolean Capital(string password)
        {
            bool ans = password.Any(Char.IsUpper);
            return ans;
        }
        public PersonValidator()
        {
            RuleFor(x => x.PersonId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Must not be empty")
                .NotNull().WithMessage("Must not be null");

            RuleFor(person => person.PersonName).NotEmpty().WithMessage("Name is required").Length(5, 15);

            RuleFor(person => person.PersonContact)
               .NotEmpty().WithMessage("Number must be greater than 0")
               .Unless(person => string.IsNullOrEmpty(person.PersonContact))
               .Matches(@"^\d{10}$").WithMessage("Contact number must be exactly 10 digits.");

            RuleFor(person => person.PersonEmail).EmailAddress().WithMessage("Invalid email address");

            RuleFor(x => x.Age).InclusiveBetween(18, 100).WithMessage("Age is between 18 to 100");

            RuleFor(x => x.NoOfFriends).ExclusiveBetween(5, 50);

            RuleFor(x => x.CreditCardNumber).CreditCard().WithMessage("Enter correct credit card number");

            RuleFor(x => x.Amount).PrecisionScale(10, 2, true).WithMessage("Amount must have upto 2 decimal places and maximum 10 digits");

            RuleFor(x => x.Password)
              .Cascade(CascadeMode.Stop)
              .NotEmpty().WithMessage("Password must not be empty")
              .NotNull().WithMessage("Password must not be empty")
              .Length(15, 30).WithMessage("Password Length must be between 15,30")
              .Must(Capital).WithMessage("Password must contain capital letter")
              .Matches(@"[^a-zA-Z0-9]").WithMessage("Password must contain special character");

            RuleFor(x => x.ConfirmPassword)
                .NotNull()
                .NotEmpty().WithMessage("Confirm Password must not be empty")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Password)
                    .NotEmpty().WithMessage("For confirm password, password must not be empty");
                })
                .Equal(x => x.Password).WithMessage("Password must be equal to confirm password");
            RuleFor(x => x.CheckedTermsConditions == true);
        }
    }
}