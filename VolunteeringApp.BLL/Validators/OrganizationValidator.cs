using FluentValidation;
using VolunteeringApp.BLL.DTOs.Organization;

namespace VolunteeringApp.BLL.Validators;

public class OrganizationValidator : AbstractValidator<CreateOrganizationDTO>
{
    public OrganizationValidator()
    {
        RuleFor(co => co.Name)
            .NotNull()
            .NotEmpty()
            .Length(0, 100);
        RuleFor(co => co.Email)
             .NotNull()
             .EmailAddress();
        RuleFor(co => co.PhoneNumber)
             .NotNull()
             .NotEmpty()
             .Length(13);
        RuleFor(co => co.Description)
            .NotNull()
            .NotEmpty();
        RuleFor(co => co.City)
            .NotNull()
            .NotEmpty()
            .Length(0, 100);
        RuleFor(co => co.Address)
            .NotNull()
            .NotEmpty();
    }
}
