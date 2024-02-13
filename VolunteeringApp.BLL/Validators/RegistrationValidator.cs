//using FluentValidation;
//using System.Text.RegularExpressions;
//using VolunteeringApp.BLL.DTOs.User.Requests;

//namespace VolunteeringApp.BLL.Validators;

//public class RegistrationValidator : AbstractValidator<RegistrationViewModel>
//{
//    public RegistrationValidator()
//    {
//        RuleFor(ur => ur.Name)
//            .NotNull()
//            .NotEmpty()
//            .Length(0, 100);
//        RuleFor(ur => ur.Surname)
//            .NotNull()
//            .NotEmpty()
//            .Length(0, 100);
//        RuleFor(ur => ur.Email)
//             .NotNull()
//             .EmailAddress();
//        RuleFor(ur => ur.UserName)
//             .NotNull()
//             .NotEmpty();
//        RuleFor(ur => ur.PhoneNumber)
//             .NotNull()
//             .NotEmpty();
//        RuleFor(ur => ur.Password)
//             .NotNull()
//             .NotEmpty()
//             .Length(5, 15)
//             .Must(password => IsValidPassword(password));

//        When(x => x.IsOrganizationRep, () =>
//        {
//            RuleFor(x => x.CreateOrganizationDTO).NotNull().SetValidator(new OrganizationValidator());
//        });
//    }

//    private bool IsValidPassword(string password)
//    {
//        var lowercase = new Regex("[a-z]+");
//        var uppercase = new Regex("[A-Z]+");
//        var digit = new Regex("(\\d)+");
//        var symbol = new Regex("(\\W)+");

//        return lowercase.IsMatch(password)
//            && uppercase.IsMatch(password)
//            && digit.IsMatch(password)
//            && symbol.IsMatch(password);
//    }
//}
