using FluentValidation;

namespace DistributedSystem.Contract.Services.V1.Identity.Validators;

public class LoginValidator : AbstractValidator<Query.Login>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}