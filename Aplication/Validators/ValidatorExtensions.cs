using FluentValidation;

namespace Aplication.Validators
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty()
                .MinimumLength(6).WithMessage("Password must be at least 6 characters")
                .Matches("[A-Z]").WithMessage("Password must contain 1 uppercase letter")
                .Matches("[a-z]").WithMessage("Password must contain 1 lowercase letter")
                .Matches("[0-9]").WithMessage("Password must contain a number")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain non alphanumeric");

                return options;
        }

                public static IRuleBuilder<T, string> PhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .Matches("[0-9]").WithMessage("Only numbers allow for Phone number")
                .MaximumLength(11).WithMessage("Phone number can not be more than 11 digits")
                .MinimumLength(7).WithMessage("Phone number can not be less than 8 digits");

                return options;
        }

    }
}